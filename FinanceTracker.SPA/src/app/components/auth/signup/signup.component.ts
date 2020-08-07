import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user.model';
import { UiService } from 'src/app/services/ui.service';
import { TimeZoneList } from 'src/app/data/timezone.data';
import { CurrencyList } from 'src/app/data/currency.data';
import { Subscription } from 'rxjs';
import { ErrorUserNameAlreadyTakenMatcher } from 'src/app/errorMatchers/error-username-already-taken.matcher';

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
  timeZones = [];
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

  private getTimezoneByCountry(countryName: string): string[] {
    return TimeZoneList.filter((tz) => {
      return ( tz.countryName === countryName );
    }).map((tz) => {
      return ( `(UTC ${tz.rawFormat.substring(0, 6)}) ${tz.mainCities.join(', ')}` );
    }).sort();
  }

  private getCountries(): string[] {
    return TimeZoneList.map((tz) => {
      return (
        tz.countryName
      );
    }).sort();
  }

  onSubmit(form: NgForm) {
      const user = Object.assign({}, form.value);
      const subscription = this.authService.registerUser({ userName: user.userName, password: user.password,
            timeZone: user.timeZone, dateOfBirth: user.birthdayPicker,
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
