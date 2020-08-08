import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { JwtModule } from '@auth0/angular-jwt';

import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './material.module';
import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { YesNoDialogComponent } from './shared/yes.no.dialog.component';
import { ExpenseAddComponent } from './components/expense-add/expense-add.component';
import { CategoryAddComponent } from './components/category-add/category-add.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { HeaderComponent } from './components/navigation/header/header.component';
import { SidenavListComponent } from './components/navigation/sidenav-list/sidenav-list.component';
import { UiService } from './services/ui.service';
import { AuthService } from './services/auth.service';
import { CurrencyService } from './services/currency.service';
import { ExpenseService } from './services/expense.service';
import { CategoryService } from './services/category.service';
import { BankAccountService } from './services/bank-account.service';
import { AccountService } from './services/account.service';
import { reducers } from './reducers/app.reducer';
import { DatePipe } from '@angular/common';
import { AuthModule } from './components/auth/auth.module';
import { BankAccountAddComponent } from './components/bank-account-add/bank-account-add.component';
import { AccountAddEditComponent } from './components/account-add-edit/account-add-edit.component';
import { AccountActionsComponent } from './components/account-actions/account-actions.component';
import { AccountTransactionsComponent } from './components/account-transactions/account-transactions.component';
import { TransactionService } from './services/transaction.service';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    HeaderComponent,
    SidenavListComponent,
    YesNoDialogComponent,
    ExpenseAddComponent,
    CategoryAddComponent,
    BankAccountAddComponent,
    AccountAddEditComponent,
    AccountActionsComponent,
    AccountTransactionsComponent
  ],
  imports: [
    SharedModule,
    HttpClientModule,
    FlexLayoutModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    AuthModule,
    StoreModule.forRoot(reducers),
    JwtModule.forRoot({
       config: {
          tokenGetter: tokenGetter,
          whitelistedDomains: ['localhost:5000'],
          blacklistedRoutes: ['localhost:5000/api/auth']
       }
    })
  ],
  providers: [
    AuthService,
    CurrencyService,
    CategoryService,
    BankAccountService,
    TransactionService,
    AccountService,
    ExpenseService,
    UiService,
    DatePipe
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    YesNoDialogComponent,
    ExpenseAddComponent,
    CategoryAddComponent,
    BankAccountAddComponent,
    AccountAddEditComponent,
    AccountActionsComponent,
    AccountTransactionsComponent
  ]
})
export class AppModule { }
