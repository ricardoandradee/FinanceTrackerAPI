import { Component, OnInit,  EventEmitter, Output, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { CurrencyList } from 'src/app/models/currency.model';
import { CurrencyService } from 'src/app/services/currency.service';
import { User } from 'src/app/models/user.model';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
  @Output() sidenavToggle = new EventEmitter<void>();
  private allSubscriptions: Subscription[] = [];
  currencies = [];
  userBaseCurrency = '';
  openSideNav = false;
  disableBaseCurrency = true;
  isAuth$: Observable<boolean>;

  constructor(private authService: AuthService,
              private currencyService: CurrencyService) {
    this.currencies = CurrencyList;
   }

  ngOnInit() {
    this.isAuth$ = this.authService.getIsAuthenticated;
    this.allSubscriptions.push(this.currencyService.getUserBaseCurrency.subscribe(currency => {
      this.userBaseCurrency = currency ? currency : 'EUR';
    }));
  }

  saveUserBaseCurrency() {
    if (!this.disableBaseCurrency) {
      const subscription = this.currencyService.updateUserBaseCurrency(this.userBaseCurrency)
      .subscribe(response => {
        const user = this.getUserBaseCurrencyFromLocalStorage();
        this.currencyService.setUserBaseCurrency = this.userBaseCurrency;
        user.userCurrency = this.userBaseCurrency;
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
    this.authService.logout();
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}