import { Component, OnInit } from '@angular/core';
import { User } from './models/user.model';
import { CurrencyService } from './services/currency.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'finance-tracker';
  openSideNav = false;

  constructor(private currencyService: CurrencyService) {}
  
  unToggle() {
  }

  ngOnInit() {
      const user: User = JSON.parse(localStorage.getItem('user'));
      this.currencyService.setUserBaseCurrency = user.userCurrency;
  }
}