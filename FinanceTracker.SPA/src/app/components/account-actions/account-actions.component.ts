import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Account } from 'src/app/models/account.model';

@Component({
  selector: 'app-account-actions',
  templateUrl: './account-actions.component.html',
  styleUrls: ['./account-actions.component.scss']
})
export class AccountActionsComponent implements OnInit {
  action = 'Deposit';
  amount: number;
  account: Account;
  description: string;
  accountActions: string[] = ['Deposit', 'Withdraw'];

  constructor(@Inject(MAT_DIALOG_DATA) public passedData: any) {
    this.account = { ...passedData.account };
  }

  onSelectionChange() {
    console.log(this.action);
  }

  onSave() {

  }

  ngOnInit() {
  }

}
