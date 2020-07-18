import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { BankAccount } from 'src/app/models/bank-account.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-bank-account-add',
  templateUrl: './bank-account-add.component.html',
  styleUrls: ['./bank-account-add.component.scss']
})
export class BankAccountAddComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<BankAccountAddComponent>) {
  }
  ngOnInit(): void {
  }
  
  onSave(form: NgForm) {
    const bankInfo = { name: form.value.name, branch: form.value.branch,
      address: form.value.address, isActive: true, createdDate: new Date() } as BankAccount;
    this.dialogRef.close({ data: bankInfo });
  }

}
