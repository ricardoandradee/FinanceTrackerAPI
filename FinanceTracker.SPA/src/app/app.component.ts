import { Component, OnInit } from '@angular/core';
import { CategoryService } from './services/category.service';
import { Category } from './models/category.model';
import { PaymentService } from './services/payment.service';
import { Payment } from './models/payment.model';
import { AuthService } from './services/auth.service';
import { switchMap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CurrencyService } from './services/currency.service';
import { User } from './models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'finance-tracker';
  openSideNav = false;
  private jwtHelper = new JwtHelperService();
  private payments: Payment[];
  private categories: Category[];

  constructor(private categoryService: CategoryService,
              private paymentService: PaymentService,
              private authService: AuthService,
              private currencyService: CurrencyService) {

                const token = localStorage.getItem('token');
                if (token) {
                  this.authService.setIsAuthenticated = !this.jwtHelper.isTokenExpired(token);
                }

                const user: User = JSON.parse(localStorage.getItem('user'));
                if (user) {
                  this.currencyService.setUserBaseCurrency = user.userCurrency ? user.userCurrency : 'EUR';
                }
              }
  
  unToggle() {
  }

  ngOnInit() {
    this.authService.getIsAuthenticated.subscribe(isAuth => {
          if (isAuth) {
            const getPaymentCategoryMap = (id) => {
              return this.categoryService.getCategoriesForUser().pipe(
                switchMap(categories => 
                  this.paymentService.getPaymentsForUser().pipe(
                    switchMap(payments => [{ categories: categories, payments: payments }])
                  )
                )
              )
            };

            getPaymentCategoryMap(0).subscribe(result => {
              this.categories = result.categories;
              this.payments = result.payments;
            }).add(() => {
              this.updatePaymentCategoryContainers();
            });
          }
      });
  }

  
  updatePaymentCategoryContainers() {
    this.categories.forEach(c => {
      c.canBeDeleted = !this.payments.some(b => b.categoryId === c.id);
    });
    this.categoryService.setCategories = this.categories;
    this.paymentService.setPayments = this.payments;
  }
}
