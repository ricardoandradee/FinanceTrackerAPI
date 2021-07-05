import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Category } from '../../models/category.model';
import { NgForm } from '@angular/forms';
import { Expense } from '../../models/expense.model';
import { CategoryService } from 'src/app/services/category.service';
import { Subscription } from 'rxjs';
import { CommonService } from 'src/app/services/common.service';
import { Currency } from 'src/app/models/currency.model';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss']
})
export class ExpenseAddComponent implements OnDestroy, OnInit {
  private subscription: Subscription;
  @ViewChild('addExpenseForm', { static: false }) form: NgForm
  expense: Expense;
  categories: Category[] = [];
  currencies: Currency[];

  constructor(private dialogRef: MatDialogRef<ExpenseAddComponent>,
              private commonService: CommonService, private categoryService: CategoryService) {
    
    this.subscription = this.categoryService.getCategories.subscribe((categoryList: Category[]) => {
      this.categories = categoryList;
    });
    
    this.commonService.getAllCurrencies.subscribe(x => {
      this.currencies = x;
    });
  }
  
  ngOnInit() {
    let userSettings = JSON.parse(localStorage.getItem('user')) as User;
    this.expense = {
      address: "",
      establishment: "",
      category: { id: 0 } as Category,
      currency: userSettings.currency
    } as Expense;
  }
  
  onSave() {
    this.dialogRef.close({ data: this.expense });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}