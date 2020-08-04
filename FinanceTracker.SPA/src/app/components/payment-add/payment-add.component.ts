import { Component, OnDestroy } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Category } from '../../models/category.model';
import { NgForm } from '@angular/forms';
import { Payment } from '../../models/payment.model';
import { CurrencyList } from '../../models/currency.model';
import { CategoryService } from 'src/app/services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-payment-add',
  templateUrl: './payment-add.component.html',
  styleUrls: ['./payment-add.component.scss']
})
export class PaymentAddComponent implements OnDestroy {
  private subscription: Subscription;
  categories: Category[] = [];
  currencies = [];

  constructor(private dialogRef: MatDialogRef<PaymentAddComponent>, private categoryService: CategoryService) {
    
    this.subscription = this.categoryService.getCategories.subscribe((categoryList: Category[]) => {
      this.categories = categoryList;
    });
    this.currencies = CurrencyList;
  }
  
  onSave(form: NgForm) {
    const payment = {
      categoryId: form.value.category,
      address: form.value.address,
      establishment: form.value.establishment,
      description: form.value.description,
      currency: form.value.currency,
      price: form.value.price,
      createdDate: new Date()
    } as Payment;
    this.dialogRef.close({ data: payment });    
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
