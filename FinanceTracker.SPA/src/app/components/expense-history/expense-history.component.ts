import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { Expense } from '../../models/expense.model';
import { YesNoDialogComponent } from '../../shared/yes.no.dialog.component';
import { ExpenseAddComponent } from '../expense-add/expense-add.component';
import { Category } from '../../models/category.model';
import { ExpenseService } from 'src/app/services/expense.service';
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
  selector: 'app-expense-history',
  templateUrl: './expense-history.component.html',
  styleUrls: ['./expense-history.component.scss']
})

export class ExpenseHistoryComponent implements OnInit, OnDestroy {
  displayedColumns = ['CreatedDate', 'Category', 'Description', 'Establishment', 'Price', 'Actions'];
  dataSource = new MatTableDataSource<Expense>();
  private allSubscriptions: Subscription[] = [];
  isLoading$: Observable<boolean>;
  editExpense: Expense;
  oldExpense: Expense;
  rowInEditMode = false;
  private currencies: string[];
  private allCategories: Category[];

  private datesKeyValue: KeyValuePair<string, string>[];
  private categoriesKeyValue: KeyValuePair<number, string>[];
  private expenseDate = 'All';
  private category = 'All';
  userBaseCurrency: string;
  userTimeZone = '';

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  constructor(private uiService: UiService, private expenseService: ExpenseService,
              private currencyService: CurrencyService, private dialog: MatDialog,
              private categoryService: CategoryService,
              private store: Store<{ui: fromRoot.State}>) {
                this.currencies = CurrencyList;
              }

  ngOnInit() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.userTimeZone = user.timeZoneUtc;
    
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
          this.refreshExpenseDataSource();
        }, 500);
      } else {
        this.refreshExpenseDataSource();
      }
    }));
  }

  bindDataSource(expenses: Expense[]) {
    this.dataSource = new MatTableDataSource(expenses);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    
    this.dataSource.filterPredicate = (pr, filter) => {
      return this.dateFilterMatches(pr) && this.categoryFilterMatches(pr);
    };
  }

  populateDropDownLists(expenses: Expense[]) {
    this.categoriesKeyValue  = getUniquePairs(expenses.map((expense: Expense) =>
    {
        return { key: expense.categoryId, value: expense.categoryName } as KeyValuePair<number, string>;
    }));
    
    this.datesKeyValue = getUniquePairs(expenses.map((expense: Expense) =>
    {
        return { key: expense.createdDateString, value: expense.createdDateString } as KeyValuePair<string, string>;
    }));
  }

  onOpenAddExpenseDialog() {
    const dialogRef = this.dialog.open(ExpenseAddComponent);
    this.allSubscriptions.push(dialogRef.afterClosed().subscribe(result => {
      if (result.data) {
        this.createExpense(result.data as Expense);
      }
    }));
  }

  onDelete(expense: Expense) {
    const dialogRef = this.dialog.open(YesNoDialogComponent,
    { data:
      {
        message: 'Are you sure you want to delete this item from your history?',
        title: 'Are you sure?'
      }
    });

    this.allSubscriptions.push(dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.deleteExpense(expense);
      }
    }));
  }
  
  onUpdate() {
    this.store.dispatch(new UI.StartLoading());
    this.updateExpense();
  }

  private createExpense(expenseToBeCreated: Expense) {
    this.store.dispatch(new UI.StartLoading());
    const subscription = this.expenseService.createExpense(expenseToBeCreated).subscribe(response => {
      if (response.ok) {
        const expenseCreated = response.body as Expense;
        this.pushExpenseToDataSource(expenseCreated);
        this.uiService.showSnackBar('Expense was sucessfully created.', 3000);
      }
      else {
        this.uiService.showSnackBar('An error occured while adding expense details, please, try again later.', 3000);
      }
    }, (err) => {
      this.uiService.showSnackBar(`An error occured while adding expense details. Error code: ${err.status} - ${err.statusText}`, 3000);
    });

    subscription.add(() => {
      this.store.dispatch(new UI.StopLoading());
    });

    this.allSubscriptions.push(subscription);
  }
  
  private updateExpense() {
    this.store.dispatch(new UI.StartLoading());
    const subscription = this.expenseService.updateExpense(this.editExpense).subscribe(response => {
      if (response.ok) {
        this.expenseService.setExpenses = this.dataSource.data;
        this.uiService.showSnackBar('Expense successfully updated.', 3000);
        } else {
          this.uiService.showSnackBar('There was an error while trying to update your Expense. Please, try again later!', 3000);
        }
    }, (err) => {
      this.uiService.showSnackBar(`An error occured while updating expense info. Error code: ${err.status} - ${err.statusText}`, 3000);
    });

    subscription.add(() => {
      this.store.dispatch(new UI.StopLoading());      
      this.onCancelEdit();
    });

    this.allSubscriptions.push(subscription);
  }

  private deleteExpense(expense: Expense) {
    this.store.dispatch(new UI.StartLoading());
    const subscription = this.expenseService.deleteExpense(expense.id).subscribe(response => {
      this.removeExpenseFromDataSource(expense.id);
    }, (err) => {
      this.uiService.showSnackBar(`An error occured while deleting expense info. Error code: ${err.status} - ${err.statusText}`, 3000);
    });

    subscription.add(() => {
      this.store.dispatch(new UI.StopLoading());
    });

    this.allSubscriptions.push(subscription);
  }

  private refreshExpenseDataSource() {
    this.allSubscriptions.push(this.expenseService.getExpenses.subscribe((expenses: Expense[]) => {
      this.bindDataSource(expenses);
      this.populateDropDownLists(expenses);
    }));
 }

  private pushExpenseToDataSource(expenseCreated: Expense) {
    const expensesFromDataSource = this.dataSource.data;
    expensesFromDataSource.push(expenseCreated);
    this.expenseService.setExpenses = expensesFromDataSource;
  }

  private removeExpenseFromDataSource(expenseId: number) {
    const expensesFromDataSource = this.dataSource.data;
    const expenseIndex = expensesFromDataSource.findIndex(x => x.id === expenseId);
    if (expenseIndex > -1) {
      expensesFromDataSource.splice(expenseIndex, 1);
    }
    this.expenseService.setExpenses = expensesFromDataSource;
  }
  
  applyFilterByDate() {
    this.dataSource.filter = this.getDateFilter();
  }
  
  applyFilterByCategory() {
    this.dataSource.filter = '[FilterByCategory]' + this.category;
  }

  dateFilterMatches(expense: Expense): boolean {
    const filter = this.getDateFilter();
    const value = '[FilterByDate]' + expense.createdDateString;
    return filter.indexOf('[FilterByDate]') === -1 || (filter === '[FilterByDate]All' || value.indexOf(filter) >= 0);
  }

  categoryFilterMatches(expense: Expense): boolean {
    const filter = '[FilterByCategory]' + this.category;
    const value = '[FilterByCategory]' + expense.categoryId;
    return filter.indexOf('[FilterByCategory]') === -1 || (filter === '[FilterByCategory]All' || value.indexOf(filter) >= 0);
  }

  getDateFilter(): string {
    const dateToBeSearched = this.expenseDate === 'All' ? 'All' : this.expenseDate;
    return '[FilterByDate]' + dateToBeSearched;
  }

  onEdit(expense: Expense) {
    this.editExpense = expense && expense.id ? expense : {} as Expense;
    this.oldExpense = {...this.editExpense};
    this.rowInEditMode = true;
  }

  onCancelEdit() {
    this.rowInEditMode = false;
    this.editExpense = {} as Expense;
    this.oldExpense = {} as Expense;
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}
