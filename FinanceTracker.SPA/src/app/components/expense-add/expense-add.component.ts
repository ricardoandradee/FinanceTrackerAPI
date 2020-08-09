import { Component, OnDestroy } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Category } from '../../models/category.model';
import { NgForm } from '@angular/forms';
import { Expense } from '../../models/expense.model';
import { CategoryService } from 'src/app/services/category.service';
import { Subscription } from 'rxjs';
import { CommonService } from 'src/app/services/common.service';
import { Currency } from 'src/app/models/currency.model';

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss']
})
export class ExpenseAddComponent implements OnDestroy {
  private subscription: Subscription;
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
  
  onSave(form: NgForm) {
    const expense = {
      category: { id: form.value.category } as Category,
      address: form.value.address,
      establishment: form.value.establishment,
      description: form.value.description,
      currency: { id: form.value.currency } as Currency,
      price: form.value.price,
      createdDate: new Date()
    } as Expense;
    this.dialogRef.close({ data: expense });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
