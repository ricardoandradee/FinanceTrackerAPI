import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user.model';
import { UiService } from 'src/app/services/ui.service';
import { Subscription } from 'rxjs';
import { ErrorAlreadyTakenMatcher } from 'src/app/errorMatchers/error-already-taken.matcher';
import { TimeZone } from 'src/app/models/timezone.model';
import { Currency } from 'src/app/models/currency.model';
import { CommonService } from 'src/app/services/common.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit, OnDestroy {
  private userNames = [];
  private emails = [];
  isUserNameTaken = false;
  userNameMatcher = new ErrorAlreadyTakenMatcher(this.userNames);
  emailMatcher = new ErrorAlreadyTakenMatcher(this.emails);
  private allSubscriptions: Subscription[] = [];
  maxDate = new Date();
  countries = [];
  timeZones: TimeZone[];
  timeZoneCompleteList: TimeZone[];
  currencies: Currency[];

  constructor(private authService: AuthService,
              private uiService: UiService,
              private commonService: CommonService,) {
              }

  ngOnInit() {
    this.commonService.getAllCurrencies.subscribe(c => {
      this.currencies = c;
    });

    this.commonService.getAllTimezones.subscribe(t => {
      this.timeZoneCompleteList = t;
      this.countries = this.getCountries();
    });

    this.authService.allExistingUsersDetails.subscribe((un) => {
      un.forEach((i: any) => {
          this.userNames.push(i.userName);
          this.emails.push(i.email);
      });
    });

    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  filterCity(form: NgForm) {
    this.timeZones = this.getTimezoneByCountry(form.value.country);
  }

  private getTimezoneByCountry(countryName: string): TimeZone[] {
    return this.timeZoneCompleteList.filter((tz) => {
      return ( tz.country === countryName );
    });
  }

  private getCountries(): string[] {
    const allCountries = this.timeZoneCompleteList.map((tz) => {
      return (
        tz.country
      );
    }).sort();
    return Array.from(new Set(allCountries.map(item => item)));
  }

  onSubmit(form: NgForm) {
      const user = Object.assign({}, form.value);
      const subscription = this.authService.registerUser({ userName: user.userName, password: user.password,
            stateTimeZoneId: user.timeZone, email: user.email,
            currency: { id: user.currency } as Currency, country: user.country } as User).subscribe(() => {
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
    this.allSubscriptions.forEach(s => { s.unsubscribe() });
  }
}
