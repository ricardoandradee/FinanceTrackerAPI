import { Component, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MatRadioChange, MAT_DIALOG_DATA } from '@angular/material';
import { Category } from '../../models/category.model';
import { Expense } from '../../models/expense.model';
import { CategoryService } from 'src/app/services/category.service';
import { Subscription } from 'rxjs';
import { CommonService } from 'src/app/services/common.service';
import { Currency } from 'src/app/models/currency.model';
import { BankAccountService } from 'src/app/services/bank-account.service';
import { CurrencyService } from 'src/app/services/currency.service';
import { AccountDropdown } from 'src/app/models/account-dropdown.model';
import { CurrencyConverterMapper } from 'src/app/models/currency.converter.mapper.model';
import { Transaction } from 'src/app/models/transaction.model';

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss']
})
export class ExpenseAddComponent implements OnDestroy, OnInit {
  private allSubscriptions: Subscription[] = [];
  paymentStatuses: boolean[] = [true, false];
  accountDropdownList: AccountDropdown[];
  expense: Expense;
  categories: Category[] = [];
  currencies: Currency[];
  isEditMode = false;
  isInitiallyPaid = false;
  currencyConverted = '';

  constructor(@Inject(MAT_DIALOG_DATA) public passedData: any,
              private dialogRef: MatDialogRef<ExpenseAddComponent>,
              private commonService: CommonService,
              private categoryService: CategoryService,
              private currencyService: CurrencyService,
              private bankAccountService: BankAccountService) {
                this.expense = passedData.expense as Expense;
                this.isInitiallyPaid = this.expense.isPaid;
                this.isEditMode = passedData.isEditMode;
    
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
    const bankAccountSubscription = this.bankAccountService.getBankAccountInfos.subscribe(bank => {
      this.accountDropdownList = [];
      for (let b of bank) {
        let bankName = b.name;
        for (let a of b.accounts) {
          this.accountDropdownList.push({
            accountId: a.id,
            description: bankName + ' - ' + a.number,
            currency: a.currency.code
          } as AccountDropdown);
        }
      }
    });
    this.allSubscriptions.push(bankAccountSubscription);
  }

  onPaymentStatusChange($event: MatRadioChange) {
    var selection = $event.value;
    this.currencyConverted = '';
    if (!selection) {
      this.expense.transaction = null;
    } else {
      this.expense.transaction = { } as Transaction;
    }
  }

  onPaymentChange() {
    this.currencyConverted = '';
    const accountId = this.expense.transaction ? this.expense.transaction.accountId : null;
    var map = this.getMappedCurrency(accountId, this.expense.price);
    if (map) {
      this.expense.transaction.amount = map.price;
      if (map.currencyFrom !== map.currencyTo) {
        let valueConverted = this.currencyService.convertCurrency(map);
        this.expense.transaction.amount = valueConverted;
        this.currencyConverted = `Total payment in ${map.currencyTo}: ${valueConverted.toFixed(2)}`;
      }
      this.expense.transaction.action = 'Debit';
      this.expense.transaction.description = `Payment at ${this.expense.establishment}.`;
    }
  }

  getMappedCurrency(accountId: number, price: number): CurrencyConverterMapper {
    if (accountId && price > 0) {
      let item = this.accountDropdownList.find(a => a.accountId === accountId);
        return { currencyFrom: this.expense.currency.code, currencyTo: item.currency,
          price: price } as CurrencyConverterMapper;
    }
    return null;
  }
  
  onSave() {
    if (this.isEditMode) {
      this.expense.isPaid = this.expense.transaction.accountId ? true : false;
    }
    this.expense.transaction = this.expense.transaction && this.expense.transaction.accountId ? this.expense.transaction : null;
    this.dialogRef.close({ data: this.expense });
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe() });
  }
}