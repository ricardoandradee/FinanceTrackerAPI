import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { CategoryService } from './services/category.service';
import { Category } from './models/category.model';
import { PaymentService } from './services/payment.service';
import { Payment } from './models/payment.model';
import { AuthService } from './services/auth.service';
import { switchMap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CurrencyService } from './services/currency.service';
import { User } from './models/user.model';
import { SidenavListComponent } from './components/navigation/sidenav-list/sidenav-list.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  @ViewChild(SidenavListComponent, { static: false }) sidNav: SidenavListComponent;

  private jwtHelper = new JwtHelperService();
  private payments: Payment[];
  private categories: Category[];
  private allSubscriptions: Subscription[] = [];

  title = 'Spend wise';
  openSideNav = false;
  sidenavWidth = 4;

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

  increase() {
    this.sidNav.sidenavWidth = 15;
    this.sidenavWidth = 15;
  }

  decrease() {
    this.sidNav.sidenavWidth = 4;
    this.sidenavWidth = 4;
  }
  
  ngOnInit() {
    this.allSubscriptions.push(this.authService.getIsAuthenticated.subscribe(isAuth => {
          if (isAuth) {
            const getPaymentCategoryMap = (id) => {
              return this.categoryService.getCategoriesForUser().pipe(
                switchMap(categories => 
                  this.paymentService.getPaymentsByUserId().pipe(
                    switchMap(payments => [{ categories: categories, payments: payments }])
                  )
                )
              )
            };

            this.allSubscriptions.push(getPaymentCategoryMap(0).subscribe(result => {
              this.categories = result.categories;
              this.payments = result.payments;
            }).add(() => {
              this.updatePaymentListToContainer();
              this.updateCategoryListToContainers();
            }));
          }
      }));
  }

  updatePaymentListToContainer() {
    this.categoryService.setCategories = this.categories;
    this.paymentService.setPayments = this.payments;
  }

  updateCategoryListToContainers() {
    this.categoryService.setCategories = this.categories;
    this.paymentService.setPayments = this.payments;
  }
  
  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}
