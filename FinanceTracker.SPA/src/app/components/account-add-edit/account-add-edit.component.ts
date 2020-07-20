import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { CurrencyList } from 'src/app/models/currency.model';
import { Account } from 'src/app/models/account.model';

@Component({
  selector: 'app-account-add-edit',
  templateUrl: './account-add-edit.component.html',
  styleUrls: ['./account-add-edit.component.scss']
})
export class AccountAddEditComponent implements OnInit {
  currencies = [];
  account: Account;
  actionMode = 'Add';

  constructor(@Inject(MAT_DIALOG_DATA) public passedData: any,
              private dialogRef: MatDialogRef<AccountAddEditComponent>) {
                this.currencies = CurrencyList;
                this.actionMode = passedData.actionMode;
                this.account = { ...passedData.account };
              }
  
  ngOnInit(): void {
  }
  
  onSave() {
    this.dialogRef.close(this.account);
  }

}
