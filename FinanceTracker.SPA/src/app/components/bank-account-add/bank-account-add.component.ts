import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { BankAccount } from 'src/app/models/bank-account.model';
import { Account } from 'src/app/models/account.model';
import { NgForm } from '@angular/forms';
import { CurrencyList } from 'src/app/models/currency.model';

@Component({
  selector: 'app-bank-account-add',
  templateUrl: './bank-account-add.component.html',
  styleUrls: ['./bank-account-add.component.scss']
})
export class BankAccountAddComponent implements OnInit {
  currencies = [];

  constructor(private dialogRef: MatDialogRef<BankAccountAddComponent>) {
  }
  ngOnInit(): void {
    this.currencies = CurrencyList;
  }
  
  onSave(form: NgForm) {
    const account = { name: 'Checking Account', description: `Checking Account linked to ${form.value.name}`,
      currentBalance: form.value.currentBalance, currency: form.value.currency,
      number: form.value.accountNumber, isActive: true, transactions: [] } as Account;
      
    const bankInfo = { name: form.value.name, branch: form.value.branch,
        isActive: true, accounts: [account] } as BankAccount;
    this.dialogRef.close({ data: bankInfo });
  }

}
