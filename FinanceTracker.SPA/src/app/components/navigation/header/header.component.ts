import { Component, OnInit,  EventEmitter, Output } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { CurrencyList } from 'src/app/models/currency.model';
import { CurrencyService } from 'src/app/services/currency.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() sidenavToggle = new EventEmitter<void>();
  private currencies = [];
  private userBaseCurrency = '';
  private disableBaseCurrency = true;

  constructor(private authService: AuthService,
              private currencyService: CurrencyService) {
    this.currencies = CurrencyList;
   }

  ngOnInit() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.userBaseCurrency = user.userCurrency ? user.userCurrency : 'EUR';
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  saveUserBaseCurrency() {
    this.currencyService.updateUserBaseCurrency(this.userBaseCurrency).subscribe(response => {
      const user: User = JSON.parse(localStorage.getItem('user'));
      user.userCurrency = this.userBaseCurrency;
      localStorage.setItem('user', JSON.stringify(user));
    });
  }

  onToggleSidenav() {
    this.sidenavToggle.emit();
  }

  onLogout() {
    this.authService.logout();
  }
}