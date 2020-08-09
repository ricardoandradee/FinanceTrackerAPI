import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user.model';
import { UiService } from 'src/app/services/ui.service';
import { CurrencyList } from 'src/app/data/currency.data';
import { Subscription } from 'rxjs';
import { ErrorUserNameAlreadyTakenMatcher } from 'src/app/errorMatchers/error-username-already-taken.matcher';
import { TimeZone } from 'src/app/models/timezone.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit, OnDestroy {
  private userNames = [];
  isUserNameTaken = false;
  matcher = new ErrorUserNameAlreadyTakenMatcher(this.userNames);
  private allSubscriptions: Subscription[] = [];
  maxDate = new Date();
  countries = [];
  timeZones: TimeZone[];
  currencies = [];

  constructor(private authService: AuthService,
              private uiService: UiService) {
              }

  ngOnInit() {
    this.authService.userNames.subscribe((un) => {
      un.forEach((i) => { this.userNames.push(i); });
    });

    this.countries = this.getCountries();
    this.currencies = CurrencyList;
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  filterCity(form: NgForm) {
    const country = form.value.country;
    this.timeZones = this.getTimezoneByCountry(country);
  }

  private getTimezoneByCountry(countryName: string): TimeZone[] {
    const timeZones: TimeZone[] = JSON.parse(localStorage.getItem('timezoneList'));
    return timeZones.filter((tz) => {
      return ( tz.country === countryName );
    });
  }

  private getCountries(): string[] {
    const timeZones: TimeZone[] = JSON.parse(localStorage.getItem('timezoneList'));
    const allCountries = timeZones.map((tz) => {
      return (
        tz.country
      );
    }).sort();
    return Array.from(new Set(allCountries.map(item => item)));
  }

  onSubmit(form: NgForm) {
      const user = Object.assign({}, form.value);
      const subscription = this.authService.registerUser({ userName: user.userName, password: user.password,
            stateTimeZoneId: user.timeZone,
            baseCurrency: user.currency, country: user.country } as User).subscribe(() => {
            this.uiService.showSnackBar('User successfully registered.', 3000);
      }, error => {
            this.uiService.showSnackBar(error, 3000);
      });

      subscription.add(() => {
        this.login(form);
      });
  
      this.allSubscriptions.push(subscription);
  }
  
  login(form: NgForm) {
    const subscription = this.authService.login({userName: form.value.userName, password: form.value.password});
    this.allSubscriptions.push(subscription);
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}
