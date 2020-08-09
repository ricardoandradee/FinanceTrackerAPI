import { Component, OnInit,  EventEmitter, Output, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { CurrencyService } from 'src/app/services/currency.service';
import { User } from 'src/app/models/user.model';
import { Observable, Subscription } from 'rxjs';
import { BankAccountService } from 'src/app/services/bank-account.service';
import { Account } from 'src/app/models/account.model';
import { Currency } from 'src/app/models/currency.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
  @Output() sidenavToggle = new EventEmitter<void>();
  private allSubscriptions: Subscription[] = [];
  currencies: Currency[];
  userBaseCurrency: Currency;
  openSideNav = false;
  disableBaseCurrency = true;
  allAccounts: Account[];
  isAuth$: Observable<boolean>;

  constructor(private authService: AuthService,
              private bankAccountService: BankAccountService,
              private currencyService: CurrencyService) {
    this.currencies = this.getCurrency();
   }

  ngOnInit() {
    this.isAuth$ = this.authService.getIsAuthenticated;
    
    const currencySubscription = this.currencyService.getUserBaseCurrency.subscribe(currency => {
      this.userBaseCurrency = currency;
    });

    const bankSubscription = this.bankAccountService.getBankAccountInfos.subscribe(bank => {
      const accounts = ([] as Account[]).concat(...bank.map(x => ( x.accounts )));
      this.allAccounts = [...accounts];
    });

    this.allSubscriptions.push(currencySubscription);
    this.allSubscriptions.push(bankSubscription);
  }

  private getCurrency(): Currency[] {
    const currencies: Currency[] = JSON.parse(localStorage.getItem('currencyList'));
    return currencies;
  }

  private getCurrencyById(id: number): Currency {
    const currency = this.getCurrency().find(x => x.id === id);
    return currency;
  }
  
  saveUserBaseCurrency() {
    if (!this.disableBaseCurrency) {
      const subscription = this.currencyService.updateUserBaseCurrency(this.userBaseCurrency.id)
      .subscribe(response => {
        const newCurrency = this.getCurrencyById(this.userBaseCurrency.id);
        const user = this.getUserBaseCurrencyFromLocalStorage();
        this.currencyService.setUserBaseCurrency = newCurrency;
        user.currency = newCurrency;
        localStorage.setItem('user', JSON.stringify(user));
      });
      this.allSubscriptions.push(subscription);
    }
    this.disableBaseCurrency = !this.disableBaseCurrency;
  }

  private getUserBaseCurrencyFromLocalStorage(): User {
      const user: User = JSON.parse(localStorage.getItem('user'));
      return user;
  }

  onToggleSidenav() {
    this.openSideNav = !this.openSideNav;
    this.sidenavToggle.emit();
  }

  onLogout() {
    if (this.openSideNav) {
      this.onToggleSidenav();
    }
    this.authService.logout();
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}