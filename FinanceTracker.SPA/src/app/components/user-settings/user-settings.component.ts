import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { TimeZone } from 'src/app/models/timezone.model';
import { Currency } from 'src/app/models/currency.model';
import { CommonService } from 'src/app/services/common.service';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.scss']
})
export class UserSettingsComponent implements OnInit {
  countries = [];
  timeZoneCompleteList: TimeZone[];
  timeZones: TimeZone[];
  currencies: Currency[];
  userSettings: User;

  constructor(private dialogRef: MatDialogRef<UserSettingsComponent>,
              private commonService: CommonService) {
    this.userSettings = JSON.parse(localStorage.getItem('user')) as User;
  }

  ngOnInit() {
    this.commonService.getAllCurrencies.subscribe(c => {
      this.currencies = c;
    });

    this.commonService.getAllTimezones.subscribe(tz => {
      this.timeZoneCompleteList = tz;
      this.countries = this.getCountries();
      this.userSettings.country = tz.find(x => x.id === this.userSettings.stateTimeZone.id).country;
      this.onCityFilterChange();
    });
  }

  onCityFilterChange() {
    this.timeZones = this.getTimezoneByCountry(this.userSettings.country);
  }
  
  private getCountries(): string[] {
    const allCountries = this.timeZoneCompleteList.map((tz) => {
      return (
        tz.country
      );
    }).sort();
    return Array.from(new Set(allCountries.map(item => item)));
  }

  private getTimezoneByCountry(countryName: string): TimeZone[] {
    return this.timeZoneCompleteList.filter((tz) => {
      return ( tz.country === countryName );
    });
  }

  onSave() {
    const user = {
      id: this.userSettings.id,
      currency: this.currencies.find(x => x.id === this.userSettings.currency.id),
      country: this.userSettings.country,
      stateTimeZone: this.timeZoneCompleteList.find(x => x.id === this.userSettings.stateTimeZone.id)
    };
    this.dialogRef.close({ data: user });
  }
}
