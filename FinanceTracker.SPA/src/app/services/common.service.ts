import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Currency } from '../models/currency.model';
import { TimeZone } from '../models/timezone.model';

@Injectable()
export class CommonService {
    private baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }
    
    public loadCurrencies() {
        const url = `${this.baseUrl}financetracker/GetListOfCurrency`;
        return this.http.get(url, { observe: 'response' })
        .pipe(map(response => {
            return response.body as Currency[];
        })).subscribe((currencies: Currency[]) => {
            localStorage.setItem('currencyList', JSON.stringify(currencies));
        });
    }

    public loadTimeZones() {
        const url = `${this.baseUrl}financetracker/GetListOfTimeZone`;
        return this.http.get(url, { observe: 'response' })
        .pipe(map(response => {
            return response.body as TimeZone[];
        })).subscribe((timezones: TimeZone[]) => {
            localStorage.setItem('timezoneList', JSON.stringify(timezones));
        });
    }
}