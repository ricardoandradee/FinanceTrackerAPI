import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CurrencyConverterMapper } from '../models/currency.converter.mapper.model';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { KeyValuePair } from '../models/key-value-pair.model';
import { User } from '../models/user.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class CurrencyService {
    private baseUrl = environment.apiUrl;
    private currencyRates: KeyValuePair<string, number>[] = [];

    constructor(private http: HttpClient) {
    }
    
    populateCurrencyRates() {
        this.getListOfCurrencies().subscribe((data: any) => {
            for(let key in data.rates) {
                this.currencyRates.push({ key: key, value: data.rates[key] });
            }
        });
    }
    
    getListOfCurrencies() {
        const url = `${this.baseUrl}currency/GetListOfCurrencies`;
        return this.http.get(url, { observe: 'response' })
        .pipe(map(response => {
            return response.body;
        }));
    }
    
    convertCurrency(mapperList: CurrencyConverterMapper): number {
        const currencyRateFrom = this.currencyRates.find((x) => x.key === mapperList.currencyFrom);
        const currencyRateTo = this.currencyRates.find((x) => x.key === mapperList.currencyTo);
        return currencyRateTo && currencyRateFrom ? mapperList.price * (currencyRateTo.value * (1 / currencyRateFrom.value)) : mapperList.price;
    }

    convertCurrencyList(mapperList: CurrencyConverterMapper[]): number {
        return mapperList.map(m => this.convertCurrency(m)).reduce((a, b) => a + b, 0);
    }

    updateUserBaseCurrency(baseCurrency: string) {
        const user: User = JSON.parse(localStorage.getItem('user')); 
        const url = `${this.baseUrl}user/${user.id}/UpdateUserBaseCurrency/${baseCurrency}`;
        
        let httpHeaders = new HttpHeaders({
            'Content-Type' : 'application/json'
        });

        return this.http.put(url, { headers: httpHeaders, observe: 'response' });
    }
}