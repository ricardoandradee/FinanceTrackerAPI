import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatTableDataSource, MatSort } from '@angular/material';
import { Transaction } from 'src/app/models/transaction.model';
import { Account } from 'src/app/models/account.model';

@Component({
  selector: 'app-account-transactions',
  templateUrl: './account-transactions.component.html',
  styleUrls: ['./account-transactions.component.scss']
})
export class AccountTransactionsComponent implements OnInit {
  account: Account;
  displayedColumns = ['Transaction', 'CreatedDate', 'Description', 'Amount', 'Balance'];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  dataSource = new MatTableDataSource<Transaction>();

  constructor(@Inject(MAT_DIALOG_DATA) public passedData: any) {
    this.account = { ...passedData.account };
    this.dataSource = new MatTableDataSource(this.account.transactions);
    setTimeout(() => { this.dataSource.sort = this.sort; }, 150);
  }

  ngOnInit() {
  }

}
