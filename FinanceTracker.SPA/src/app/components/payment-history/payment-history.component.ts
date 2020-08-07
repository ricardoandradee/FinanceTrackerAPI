import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { Payment } from '../../models/payment.model';
import { YesNoDialogComponent } from '../../shared/yes.no.dialog.component';
import { PaymentAddComponent } from '../payment-add/payment-add.component';
import { Category } from '../../models/category.model';
import { PaymentService } from 'src/app/services/payment.service';
import { CurrencyService } from 'src/app/services/currency.service';
import { UiService } from 'src/app/services/ui.service';
import { CurrencyList } from 'src/app/data/currency.data';
import { CategoryService } from 'src/app/services/category.service';

import { Store } from '@ngrx/store';
import * as fromRoot from 'src/app/reducers/app.reducer';
import * as UI from 'src/app/actions/ui.actions';
import { Observable, Subscription } from 'rxjs';
import { KeyValuePair, getUniquePairs } from 'src/app/models/key-value-pair.model';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-payment-history',
  templateUrl: './payment-history.component.html',
  styleUrls: ['./payment-history.component.scss']
})

export class PaymentHistoryComponent implements OnInit, OnDestroy {
  displayedColumns = ['CreatedDate', 'Category', 'Description', 'Establishment', 'Price', 'Actions'];
  dataSource = new MatTableDataSource<Payment>();
  private allSubscriptions: Subscription[] = [];
  isLoading$: Observable<boolean>;
  editPayment: Payment;
  oldPayment: Payment;
  rowInEditMode = false;
  private currencies: string[];
  private allCategories: Category[];

  private datesKeyValue: KeyValuePair<string, string>[];
  private categoriesKeyValue: KeyValuePair<number, string>[];
  private paymentDate = 'All';
  private category = 'All';
  userBaseCurrency: string;
  userTimeZone = '';

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  constructor(private uiService: UiService, private paymentService: PaymentService,
              private currencyService: CurrencyService, private dialog: MatDialog,
              private categoryService: CategoryService,
              private store: Store<{ui: fromRoot.State}>) {
                const user: User = JSON.parse(localStorage.getItem('user'));
                this.userTimeZone = user.timeZone;
                
                this.currencies = CurrencyList;
              }

  ngOnInit() {
    this.isLoading$ = this.store.select(fromRoot.getIsLoading);
    this.allSubscriptions.push(this.categoryService.getCategories.subscribe((categoryList: Category[]) => {
      this.allCategories = categoryList;
    }));

    this.allSubscriptions.push(this.currencyService.getUserBaseCurrency.subscribe((userBaseCurrency: string) => {
      this.userBaseCurrency = userBaseCurrency;
    }));
    
    this.allSubscriptions.push(this.isLoading$.subscribe(loading => {
      if (loading) {
        setTimeout(() => {
          this.refreshPaymentDataSource();
        }, 500);
      } else {
        this.refreshPaymentDataSource();
      }
    }));
  }

  bindDataSource(payments: Payment[]) {
    this.dataSource = new MatTableDataSource(payments);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    
    this.dataSource.filterPredicate = (pr, filter) => {
      return this.dateFilterMatches(pr) && this.categoryFilterMatches(pr);
    };
  }

  populateDropDownLists(payments: Payment[]) {
    this.categoriesKeyValue  = getUniquePairs(payments.map((payment: Payment) =>
    {
        return { key: payment.categoryId, value: payment.categoryName } as KeyValuePair<number, string>;
    }));
    
    this.datesKeyValue = getUniquePairs(payments.map((payment: Payment) =>
    {
        return { key: payment.createdDateString, value: payment.createdDateString } as KeyValuePair<string, string>;
    }));
  }

  onOpenAddPaymentDialog() {
    const dialogRef = this.dialog.open(PaymentAddComponent);
    this.allSubscriptions.push(dialogRef.afterClosed().subscribe(result => {
      if (result.data) {
        this.createPayment(result.data as Payment);
      }
    }));
  }

  onDelete(payment: Payment) {
    const dialogRef = this.dialog.open(YesNoDialogComponent,
    { data:
      {
        message: 'Are you sure you want to delete this item from your history?',
        title: 'Are you sure?'
      }
    });

    this.allSubscriptions.push(dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.deletePayment(payment);
      }
    }));
  }
  
  onUpdate() {
    this.store.dispatch(new UI.StartLoading());
    this.updatePayment();
  }

  private createPayment(paymentToBeCreated: Payment) {
    this.store.dispatch(new UI.StartLoading());
    const subscription = this.paymentService.createPayment(paymentToBeCreated).subscribe(response => {
      if (response.ok) {
        const paymentCreated = response.body as Payment;
        this.pushPaymentToDataSource(paymentCreated);
        this.uiService.showSnackBar('Payment was sucessfully created.', 3000);
      }
      else {
        this.uiService.showSnackBar('An error occured while adding payment details, please, try again later.', 3000);
      }
    }, (err) => {
      this.uiService.showSnackBar(`An error occured while adding payment details. Error code: ${err.status} - ${err.statusText}`, 3000);
    });

    subscription.add(() => {
      this.store.dispatch(new UI.StopLoading());
    });

    this.allSubscriptions.push(subscription);
  }
  
  private updatePayment() {
    this.store.dispatch(new UI.StartLoading());
    const subscription = this.paymentService.updatePayment(this.editPayment).subscribe(response => {
      if (response.ok) {
        this.paymentService.setPayments = this.dataSource.data;
        this.uiService.showSnackBar('Payment successfully updated.', 3000);
        } else {
          this.uiService.showSnackBar('There was an error while trying to update your Payment. Please, try again later!', 3000);
        }
    }, (err) => {
      this.uiService.showSnackBar(`An error occured while updating payment info. Error code: ${err.status} - ${err.statusText}`, 3000);
    });

    subscription.add(() => {
      this.store.dispatch(new UI.StopLoading());      
      this.onCancelEdit();
    });

    this.allSubscriptions.push(subscription);
  }

  private deletePayment(payment: Payment) {
    this.store.dispatch(new UI.StartLoading());
    const subscription = this.paymentService.deletePayment(payment.id).subscribe(response => {
      this.removePaymentFromDataSource(payment.id);
    }, (err) => {
      this.uiService.showSnackBar(`An error occured while deleting payment info. Error code: ${err.status} - ${err.statusText}`, 3000);
    });

    subscription.add(() => {
      this.store.dispatch(new UI.StopLoading());
    });

    this.allSubscriptions.push(subscription);
  }

  private refreshPaymentDataSource() {
    this.allSubscriptions.push(this.paymentService.getPayments.subscribe((payments: Payment[]) => {
      this.bindDataSource(payments);
      this.populateDropDownLists(payments);
    }));
 }

  private pushPaymentToDataSource(paymentCreated: Payment) {
    const paymentsFromDataSource = this.dataSource.data;
    paymentsFromDataSource.push(paymentCreated);
    this.paymentService.setPayments = paymentsFromDataSource;
  }

  private removePaymentFromDataSource(paymentId: number) {
    const paymentsFromDataSource = this.dataSource.data;
    const paymentIndex = paymentsFromDataSource.findIndex(x => x.id === paymentId);
    if (paymentIndex > -1) {
      paymentsFromDataSource.splice(paymentIndex, 1);
    }
    this.paymentService.setPayments = paymentsFromDataSource;
  }
  
  applyFilterByDate() {
    this.dataSource.filter = this.getDateFilter();
  }
  
  applyFilterByCategory() {
    this.dataSource.filter = '[FilterByCategory]' + this.category;
  }

  dateFilterMatches(payment: Payment): boolean {
    const filter = this.getDateFilter();
    const value = '[FilterByDate]' + payment.createdDateString;
    return filter.indexOf('[FilterByDate]') === -1 || (filter === '[FilterByDate]All' || value.indexOf(filter) >= 0);
  }

  categoryFilterMatches(payment: Payment): boolean {
    const filter = '[FilterByCategory]' + this.category;
    const value = '[FilterByCategory]' + payment.categoryId;
    return filter.indexOf('[FilterByCategory]') === -1 || (filter === '[FilterByCategory]All' || value.indexOf(filter) >= 0);
  }

  getDateFilter(): string {
    const dateToBeSearched = this.paymentDate === 'All' ? 'All' : this.paymentDate;
    return '[FilterByDate]' + dateToBeSearched;
  }

  onEdit(payment: Payment) {
    this.editPayment = payment && payment.id ? payment : {} as Payment;
    this.oldPayment = {...this.editPayment};
    this.rowInEditMode = true;
  }

  onCancelEdit() {
    this.rowInEditMode = false;
    this.editPayment = {} as Payment;
    this.oldPayment = {} as Payment;
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}
