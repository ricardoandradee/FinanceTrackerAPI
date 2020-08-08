import { NgModule } from '@angular/core';
import { FinanceComponent } from './finance.component';
import { SharedModule } from '../../shared/shared.module';
import { FinanceRoutingModule } from './finance-routing.module';
import { PaymentHistoryComponent } from '../payment-history/payment-history.component';
import { CategoryListComponent } from '../category-list/category-list.component';
import { BankAccountListComponent } from '../bank-account-list/bank-account-list.component';
import { CdkDetailRowDirective } from '../../directives/detail-row.directive';
import { PaymentTotalPricePipe } from 'src/app/pipes/payment-total-price.pipe';

@NgModule({
    declarations: [
        FinanceComponent,
        CategoryListComponent,
        BankAccountListComponent,
        PaymentHistoryComponent,
        CdkDetailRowDirective,
        PaymentTotalPricePipe
    ],
    entryComponents: [BankAccountListComponent],
    bootstrap: [BankAccountListComponent],
    imports: [
        SharedModule,
        FinanceRoutingModule
    ]
})

export class FinanceModule {

}