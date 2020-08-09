import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { CategoryService } from './services/category.service';
import { Category } from './models/category.model';
import { ExpenseService } from './services/expense.service';
import { Expense } from './models/expense.model';
import { AuthService } from './services/auth.service';
import { switchMap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CurrencyService } from './services/currency.service';
import { User } from './models/user.model';
import { SidenavListComponent } from './components/navigation/sidenav-list/sidenav-list.component';
import { Subscription } from 'rxjs';
import { CommonService } from './services/common.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  @ViewChild(SidenavListComponent, { static: false }) sidNav: SidenavListComponent;

  private jwtHelper = new JwtHelperService();
  private expenses: Expense[];
  private categories: Category[];
  private allSubscriptions: Subscription[] = [];

  title = 'Spend wise';
  openSideNav = false;
  sidenavWidth = 4;

  constructor(private categoryService: CategoryService,
              private expenseService: ExpenseService,
              private commonService: CommonService,
              private authService: AuthService,
              private currencyService: CurrencyService) {
                if (!localStorage.getItem('currencyList')) {
                  this.commonService.loadCurrencies();
                }
                if (!localStorage.getItem('timezoneList')) {
                  this.commonService.loadTimeZones();
                }

                const token = localStorage.getItem('token');
                if (token) {
                  this.authService.setIsAuthenticated = !this.jwtHelper.isTokenExpired(token);
                }

                const user: User = JSON.parse(localStorage.getItem('user'));
                if (user) {
                  this.currencyService.setUserBaseCurrency = user.baseCurrency ? user.baseCurrency : 'EUR';
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
            const getExpenseCategoryMap = (id) => {
              return this.categoryService.getCategoriesByUserId().pipe(
                switchMap(categories => 
                  this.expenseService.getExpensesByUserId().pipe(
                    switchMap(expenses => [{ categories: categories, expenses: expenses }])
                  )
                )
              )
            };

            this.allSubscriptions.push(getExpenseCategoryMap(0).subscribe(result => {
              this.categories = result.categories;
              this.expenses = result.expenses;
            }).add(() => {
              this.updateExpenseListToContainer();
              this.updateCategoryListToContainers();
            }));
          }
      }));
  }

  updateExpenseListToContainer() {
    this.categoryService.setCategories = this.categories;
    this.expenseService.setExpenses = this.expenses;
  }

  updateCategoryListToContainers() {
    this.categoryService.setCategories = this.categories;
    this.expenseService.setExpenses = this.expenses;
  }
  
  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}
