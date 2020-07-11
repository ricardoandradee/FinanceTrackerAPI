import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user.model';
import { Router } from '@angular/router';
import { UiService } from 'src/app/services/ui.service';
import { CountryCityList } from 'src/app/models/country-city.model';
import { CurrencyList } from 'src/app/models/currency.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  maxDate = new Date();
  countries = [];
  cities = [];
  currencies = [];

  constructor(private authService: AuthService, private uiService: UiService, private router: Router) {
  }

  ngOnInit() {
    this.countries = Object.keys(CountryCityList);
    this.currencies = CurrencyList;
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  filterCity(form: NgForm) {
    const country = form.value.country;
    this.cities = CountryCityList[country];
  }

  onSubmit(form: NgForm) {
      const user = Object.assign({}, form.value);
      this.authService.registerUser({ userName: user.userName, password: user.password, created: new Date(),
            lastActive: new Date(), city: user.city, country: user.country } as User).subscribe(() => {
            this.uiService.showSnackBar('User successfully registered.', 3000);
      }, error => {
            this.uiService.showSnackBar(error, 3000);
      }, () => {
        this.authService.login({userName: form.value.userName, password: form.value.password});
      });
  }
}
