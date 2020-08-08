import { Component, OnDestroy } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Category } from '../../models/category.model';
import { NgForm } from '@angular/forms';
import { Expense } from '../../models/expense.model';
import { CurrencyList } from '../../data/currency.data';
import { CategoryService } from 'src/app/services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss']
})
export class ExpenseAddComponent implements OnDestroy {
  private subscription: Subscription;
  categories: Category[] = [];
  currencies = [];

  constructor(private dialogRef: MatDialogRef<ExpenseAddComponent>, private categoryService: CategoryService) {
    
    this.subscription = this.categoryService.getCategories.subscribe((categoryList: Category[]) => {
      this.categories = categoryList;
    });
    this.currencies = CurrencyList;
  }
  
  onSave(form: NgForm) {
    const expense = {
      categoryId: form.value.category,
      address: form.value.address,
      establishment: form.value.establishment,
      description: form.value.description,
      currency: form.value.currency,
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
