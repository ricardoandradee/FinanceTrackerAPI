import { User } from '../models/user.model';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { UiService } from './ui.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CurrencyService } from './currency.service';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable()
export class AuthService {
  private baseUrl = environment.apiUrl + 'auth/';
  private jwtHelper = new JwtHelperService();
  private isAuth$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private existingUserNames$: BehaviorSubject<string[]> = new BehaviorSubject([]);
  
  currentUser: User;
  decodedToken: any;

    constructor(private http: HttpClient,
                private uiService: UiService,
                private currencyService: CurrencyService,
                private router: Router) {
                  
                  this.getAllUserNames().subscribe((response) => {
                    if(response.ok) {
                      const allUserNames = response.body as string[];
                      this.existingUserNames$.next(allUserNames);
                    }
                  });
                }

  registerUser(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
  }

  get getIsAuthenticated(): Observable<boolean> {
    return this.isAuth$.asObservable();
  }

  get userNames(): Observable<string[]> {
    return this.existingUserNames$.asObservable();
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

  private getAllUserNames(): Observable<HttpResponse<Object>> {
    const url = `${this.baseUrl}GetAllUserNames`;    
    return this.http.get(url, { observe: 'response' });
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
          this.currencyService.setUserBaseCurrency = this.currentUser.baseCurrency;
        }
        this.uiService.showSnackBar('Successfully logged in.', 3000);
        this.setIsAuthenticated = true;
        this.router.navigate(['/finance/income']);
      }
    }, (err) => {
      this.uiService.showSnackBar(`An error occured while processing login. Error code: ${err.status} - ${err.statusText}`, 3000);
    });
  }
}