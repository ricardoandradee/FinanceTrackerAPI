import { Component, OnInit, Inject, ViewChild, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatTableDataSource, MatSort } from '@angular/material';
import { Transaction } from 'src/app/models/transaction.model';
import { Account } from 'src/app/models/account.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-account-transactions',
  templateUrl: './account-transactions.component.html',
  styleUrls: ['./account-transactions.component.scss']
})
export class AccountTransactionsComponent implements OnInit, OnDestroy {
  private subscription: Subscription;
  account: Account;
  userTimeZone = '';
  displayedColumns = ['CreatedDate', 'Description', 'Amount', 'Balance'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  dataSource = new MatTableDataSource<Transaction>();

  constructor(@Inject(MAT_DIALOG_DATA) public passedData: any, private userService: UserService) {    
    this.account = { ...passedData.account };
    this.dataSource = new MatTableDataSource(this.account.transactions);
    setTimeout(() => { this.dataSource.sort = this.sort; }, 150);
  }

  ngOnInit() {
    const subscription = this.userService.getUserSettings.subscribe((user: User) => {
      this.userTimeZone = user.stateTimeZone.utc;
    });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
