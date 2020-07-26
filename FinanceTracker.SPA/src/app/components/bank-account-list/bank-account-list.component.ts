import { Component, OnInit, ViewChild, Input, ViewChildren, QueryList } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { YesNoDialogComponent } from '../../shared/yes.no.dialog.component';
import { UiService } from '../../services/ui.service';
import { BankAccountService } from 'src/app/services/bank-account.service';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import * as fromRoot from 'src/app/reducers/app.reducer';
import * as UI from 'src/app/actions/ui.actions';
import { BankAccount } from 'src/app/models/bank-account.model';
import { BankAccountAddComponent } from '../bank-account-add/bank-account-add.component';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { Account } from 'src/app/models/account.model';
import { AccountAddEditComponent } from '../account-add-edit/account-add-edit.component';
import { AccountService } from 'src/app/services/account.service';
import { CdkDetailRowDirective } from 'src/app/directives/detail-row.directive';
import { AccountActionsComponent } from '../account-actions/account-actions.component';

@Component({
  selector: 'app-bank-account-list',
  templateUrl: './bank-account-list.component.html',
  styleUrls: ['./bank-account-list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('void', style({ height: '0px', minHeight: '0', visibility: 'hidden' })),
      state('*', style({ height: '*', visibility: 'visible' })),
      transition('void <=> *', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class BankAccountListComponent implements OnInit {
  displayedColumns = ['CreatedDate', 'Name', 'Branch', 'Status', 'Actions'];
  dataSource = new MatTableDataSource<BankAccount>();
  isLoading$: Observable<boolean>;
  accountAction = 'withdraw';

  isExpansionDetailRow = (index, row) => row.hasOwnProperty('accounts');
  @Input() singleChildRowDetail: boolean;

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChildren(CdkDetailRowDirective) detailRows: QueryList<CdkDetailRowDirective>;
  
  editBankInfo: BankAccount;
  oldBankInfo: { id?: number; userId?: string; branch: string;
                 isActive: boolean, createdDate?: Date; };
  rowInEditMode: boolean;
  
  constructor(private dialog: MatDialog, private uiService: UiService,
              private bankAccountService: BankAccountService,
              private accountService: AccountService,
              private store: Store<{ui: fromRoot.State}>) { }

  ngOnInit() {
    this.isLoading$ = this.store.select(fromRoot.getIsLoading);
    this.bankAccountService.getBanksForUser().subscribe((bankInfos: BankAccount[]) => {
      this.bankAccountService.setBankAccountInfos = bankInfos;
    });
  }

  expand(element) {
    const detail = this.detailRows.find(x => x.row == element);
    detail.toggle();
  }
  
  openDialog() {
      const dialogRef = this.dialog.open(BankAccountAddComponent);
      dialogRef.afterClosed().subscribe(result => {
        if (result.data) {
          this.createBankInfo(result.data as BankAccount);
        }
      });
  }

  private createBankInfo(bankInfo: BankAccount) {
    this.store.dispatch(new UI.StartLoading());
    this.bankAccountService.createBankInfo(bankInfo).subscribe(response => {
      if (response.ok) {
        const bankInfoCreated = response.body as BankAccount;

        const bankInfosFromDataSource = this.dataSource.data;
        bankInfosFromDataSource.push(bankInfoCreated);
        this.bankAccountService.setBankAccountInfos = bankInfosFromDataSource;

        this.uiService.showSnackBar('Bank Info was sucessfully created.', 3000);
      } else {
        this.uiService.showSnackBar('There was an error while creating a Bank Info, please, try again later.', 3000);
      }
    }, (err) => {
        this.uiService.showSnackBar(err.error, 3000);
    }, () => { this.store.dispatch(new UI.StopLoading()); });
  }

  refreshBankInfoDataSource() {
    this.bankAccountService.getBankAccountInfos.subscribe((bankInfos: BankAccount[]) => {
      this.dataSource = new MatTableDataSource(bankInfos);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
 }

  ngAfterViewInit() {
    this.isLoading$.subscribe(loading => {
      if (loading) {
        setTimeout(() => {
          this.refreshBankInfoDataSource();
        }, 500);
      } else {
        this.refreshBankInfoDataSource();
      }
    });
  }

  private openedRow: CdkDetailRowDirective;
  onToggleChange(cdkDetailRow: CdkDetailRowDirective, row: BankAccount): void {
    if (this.singleChildRowDetail && this.openedRow && this.openedRow.expended) {
      this.openedRow.toggle();
    }

    row.close = !row.close;
    this.openedRow = cdkDetailRow.expended ? cdkDetailRow : undefined;
  }

  onAccountAction(account: Account) {
      const dialogRef = this.dialog.open(AccountActionsComponent,
      {
        data: { account }
      });

      dialogRef.afterClosed().subscribe((result) => {
      });

    console.log({ action: this.accountAction, account});
    this.accountAction = 'withdraw';
  }

  onShowTransactions(account: Account) {

  }

  doFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onIsActiveChange(bankInfo: BankAccount) {
    if (bankInfo.isActive && bankInfo.accounts.some(a => a.isActive)) {
      const dialogRef = this.dialog.open(YesNoDialogComponent,
      {
        data:
          {
            message: 'Are you sure you want to inactivate this bank? If you proceed, all its account will be also set to inactive.',
            title: 'Are you sure?'
          }
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (!result) {
          bankInfo.isActive = true;
        } else {
          bankInfo.accounts.forEach(a => a.isActive = false);
        }
      });
    }
  }

  onDelete(bankInfo: BankAccount) {
    const dialogRef = this.dialog.open(YesNoDialogComponent,
    {
      data:
        {
          message: 'Are you sure you want to delete this bank?',
          title: 'Are you sure?'
        }
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.store.dispatch(new UI.StartLoading());
        this.bankAccountService.deleteBankInfo(bankInfo.id).subscribe(response => {
          const bankInfoFromDataSource = this.dataSource.data;
          const bankInfoIndex = bankInfoFromDataSource.findIndex(x => x.id === bankInfo.id);
          if (bankInfoIndex > -1) {
            bankInfoFromDataSource.splice(bankInfoIndex, 1);
          }
          this.bankAccountService.setBankAccountInfos = bankInfoFromDataSource;
      }, (err) => {
          this.uiService.showSnackBar(err.error, 3000);
      }, () => { this.store.dispatch(new UI.StopLoading()); });
      }
    });
  }
  
  onAddAccout(bankInfo: BankAccount) {
    const dialogRef = this.dialog.open(AccountAddEditComponent,
    {
      data: { actionMode: 'Add', account: { bankId: bankInfo.id, name: '', isActive: true, accountCurrency: '' } as Account }
    });
    dialogRef.afterClosed().subscribe((accountToAdded: Account) => {
      if (accountToAdded) {
        this.store.dispatch(new UI.StartLoading());
        this.accountService.createAccount(accountToAdded).subscribe(response => {
          if (response.ok) {
            const accountAdded = response.body as Account;
            const bankInfoFromDataSource = this.dataSource.data;
            const bankInfoIndex = bankInfoFromDataSource.findIndex(x => x.id === accountAdded.bankId);

            if (bankInfoIndex > -1) {
              bankInfoFromDataSource[bankInfoIndex].accounts.push(accountAdded);
            }
            this.bankAccountService.setBankAccountInfos = bankInfoFromDataSource;
          }
        }, (err) => {
          this.uiService.showSnackBar(err.error, 3000);
      }, () => { this.store.dispatch(new UI.StopLoading()); });
      }
    });
  }

  onEdit(bankInfo: BankAccount) {
    this.editBankInfo = bankInfo && bankInfo.id ? bankInfo : {} as BankAccount;
    this.oldBankInfo = {...this.editBankInfo};
    this.rowInEditMode = true;
  }

  onEditAccount(account: Account, isBankActive: boolean) {
    const dialogRef = this.dialog.open(AccountAddEditComponent,
    {
      data: { actionMode: 'Edit', account, isBankActive }
    });

    dialogRef.afterClosed().subscribe((accountToEdited: Account) => {
      if (accountToEdited) {
        this.store.dispatch(new UI.StartLoading());
        this.accountService.updateAccount(accountToEdited).subscribe(response => {
          if (response.ok) {
            const bankInfoFromDataSource = this.dataSource.data;
            const bankInfoIndex = bankInfoFromDataSource.findIndex(x => x.id === accountToEdited.bankId);

            if (bankInfoIndex > -1) {
              bankInfoFromDataSource[bankInfoIndex].accounts.forEach(a => {
                if(a.id === accountToEdited.id) {
                  a.name = accountToEdited.name;
                  a.number = accountToEdited.number;
                  a.isActive = accountToEdited.isActive;
                  a.accountCurrency = accountToEdited.accountCurrency;
                }
              });
            }
            this.bankAccountService.setBankAccountInfos = bankInfoFromDataSource;
          }
        }, (err) => {
          this.uiService.showSnackBar(err.error, 3000);
      }, () => { this.store.dispatch(new UI.StopLoading()); });
      }
    });
  }

  
  onDeleteAccount(account: Account) {
    const dialogRef = this.dialog.open(YesNoDialogComponent,
    {
      data:
        {
          message: `Are you sure you want to delete this ${account.name} account?`,
          title: 'Are you sure?'
        }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.store.dispatch(new UI.StartLoading());
        this.accountService.deleteAccount(account.bankId, account.id).subscribe(response => {
          const bankInfoFromDataSource = this.dataSource.data;
          const bankInfoIndex = bankInfoFromDataSource.findIndex(b => b.id === account.bankId);
          if (bankInfoIndex > -1) {
            const accountIndex = bankInfoFromDataSource[bankInfoIndex].accounts.findIndex(a => a.id === account.id);
            if (accountIndex > -1) {
              bankInfoFromDataSource[bankInfoIndex].accounts.splice(accountIndex, 1);
            }
          }
          this.bankAccountService.setBankAccountInfos = bankInfoFromDataSource;
        }, (err) => {
          this.uiService.showSnackBar(err.error, 3000);
      }, () => { this.store.dispatch(new UI.StopLoading()); });
      }
    });
  }

  onSaveChanges() {
    this.store.dispatch(new UI.StartLoading());
    this.bankAccountService.updateBankInfo(this.editBankInfo).subscribe(response => {
      if (response.ok) {
        const bankInfoFromDataSource = this.dataSource.data;
        this.bankAccountService.setBankAccountInfos = bankInfoFromDataSource;
        this.editBankInfo = {} as BankAccount;
        this.onCancelEdit();
        this.uiService.showSnackBar('Bank info successfully updated.', 3000);
        } else {
          this.uiService.showSnackBar('There was an error while trying to update Bank info. Please, try again later!', 3000);
        }
    }, (err) => {
        this.uiService.showSnackBar(err.error, 3000);
        this.onCancelEdit();
    }, () => { this.store.dispatch(new UI.StopLoading()); });
  }

  onCancelEdit(){
    this.rowInEditMode = false;
    this.editBankInfo = {} as BankAccount;
    this.oldBankInfo = {} as BankAccount;
  }
}