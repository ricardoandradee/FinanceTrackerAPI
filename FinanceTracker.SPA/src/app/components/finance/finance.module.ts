import { NgModule } from '@angular/core';
import { FinanceComponent } from './finance.component';
import { SharedModule } from '../../shared/shared.module';
import { FinanceRoutingModule } from './finance-routing.module';
import { PaymentHistoryComponent } from '../payment-history/payment-history.component';
import { StoreModule } from '@ngrx/store';
import { CategoryListComponent } from '../category-list/category-list.component';

@NgModule({
    declarations: [
        FinanceComponent,
        CategoryListComponent,
        PaymentHistoryComponent
    ],
    imports: [
        SharedModule,
        FinanceRoutingModule
    ]
})

export class FinanceModule {

}