import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MatRadioChange } from '@angular/material';
import { Category } from '../../models/category.model';
import { NgForm } from '@angular/forms';
import { Expense } from '../../models/expense.model';
import { CategoryService } from 'src/app/services/category.service';
import { Subscription } from 'rxjs';
import { CommonService } from 'src/app/services/common.service';
import { Currency } from 'src/app/models/currency.model';
import { User } from 'src/app/models/user.model';
import { BankAccountService } from 'src/app/services/bank-account.service';
import { KeyValuePair } from 'src/app/models/key-value-pair.model';

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss']
})
export class ExpenseAddComponent implements OnDestroy, OnInit {
  private allSubscriptions: Subscription[] = [];
  @ViewChild('addExpenseForm', { static: false }) form: NgForm
  paymentStatuses: string[] = ['Paid', 'Unpaid'];
  bankAccountsKeyValue: KeyValuePair<string, string>[];
  expense: Expense;
  categories: Category[] = [];
  currencies: Currency[];

  constructor(private dialogRef: MatDialogRef<ExpenseAddComponent>,
              private commonService: CommonService,
              private categoryService: CategoryService,
              private bankAccountService: BankAccountService) {
    
    var categorySubscription = this.categoryService.getCategories.subscribe((categoryList: Category[]) => {
      this.categories = categoryList;
    });
    
    var currencySubscription = this.commonService.getAllCurrencies.subscribe(x => {
      this.currencies = x;
    });

    this.allSubscriptions.push(categorySubscription);
    this.allSubscriptions.push(currencySubscription);
  }
  
  ngOnInit() {
    let userSettings = JSON.parse(localStorage.getItem('user')) as User;
    this.expense = {
      establishment: "",
      status: 'Paid',
      category: { id: 0 } as Category,
      currency: userSettings.currency
    } as Expense;
    
    const bankAccountSubscription = this.bankAccountService.getBankAccountInfos.subscribe(bank => {
      this.bankAccountsKeyValue = [];
      for (let b of bank) {
        let bankName = b.name;
        for (let a of b.accounts) {
          this.bankAccountsKeyValue.push({
            key: a.id.toString(),
            value: bankName + ' - ' + a.number
          } as KeyValuePair<string, string>);
        }
      }
    });
    this.allSubscriptions.push(bankAccountSubscription);
  }

  onPaymentStatusChange($event: MatRadioChange) {
    var selection = $event.value;
    this.expense.amountPaid = selection === 'Paid' 
                              ? this.expense.price
                              : 0;
  }
  
  onSave() {
    this.dialogRef.close({ data: this.expense });
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe() });
  }
}