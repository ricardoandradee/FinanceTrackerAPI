import { User } from '../models/user.model';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { UiService } from './ui.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CurrencyService } from './currency.service';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable()
export class AuthService {
  private baseUrl = environment.apiUrl + 'auth/';
  private jwtHelper = new JwtHelperService();
  private isAuth$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  
  currentUser: User;
  decodedToken: any;

    constructor(private http: HttpClient,
                private uiService: UiService,
                private currencyService: CurrencyService,
                private router: Router) { }

  registerUser(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
  }

  get getIsAuthenticated(): Observable<boolean> {
    return this.isAuth$.asObservable();
  }

  set setIsAuthenticated(isAuth: boolean) {
    this.isAuth$.next(isAuth);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('currencyRates');
    this.decodedToken = null;
    this.uiService.showSnackBar('Logged out.', 3000);
    this.setIsAuthenticated = false;
    this.router.navigate(['/login']);
  }

  login(model: any) {
    const url = `${this.baseUrl}login`;
    const httpHeaders = new HttpHeaders({
        'Content-Type' : 'application/json'
    });
    
    return this.http.post(url, model, { headers: httpHeaders, observe: 'response' }).subscribe((response) => {
      if (response.ok) {
        const responseBody = response.body as any;

        if (responseBody.token) {
          localStorage.setItem('token', responseBody.token);
          this.decodedToken = this.jwtHelper.decodeToken(responseBody.token);
        }
        if (responseBody.user) {
          localStorage.setItem('user', JSON.stringify(responseBody.user));
          this.currentUser = responseBody.user;
          this.currencyService.fetchListOfCurrencies();
          this.currencyService.setUserBaseCurrency = this.currentUser.userCurrency;
        }
        this.uiService.showSnackBar('Successfully logged in.', 3000);
        this.setIsAuthenticated = true;
        console.log('here 1');
        this.router.navigate(['/finance/income']);
      }
    }, (err) => {
      this.uiService.showSnackBar(err.error, 3000);
    });
  }
}