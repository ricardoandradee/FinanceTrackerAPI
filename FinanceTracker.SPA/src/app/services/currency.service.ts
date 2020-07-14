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
    private dataSource$: BehaviorSubject<string> = new BehaviorSubject('');

    constructor(private http: HttpClient) { }

    checkIfCurrenciesAreLoaded(currencies: string[]): boolean {
        if (!this.getCurrencyRates || this.getCurrencyRates.length == 0) {
            return false;
        }

        return currencies.filter(c => this.getCurrencyRates.some(r => r.key === c)).length === currencies.length;
    }

    get getUserBaseCurrency(): Observable<string> {
        return this.dataSource$.asObservable();
    }

    set setUserBaseCurrency(userCurrency: string) {
        this.dataSource$.next(userCurrency);
    }
    
    public fetchListOfCurrencies() {
        const url = `${this.baseUrl}currency/GetListOfCurrencies`;
        return this.http.get(url, { observe: 'response' })
        .pipe(map(response => {
            return response.body;
        })).subscribe((data: any) => {
            
            const rates = Object.keys(data.rates).map((rate: any) =>
            {
                return { key: rate, value: data.rates[rate] } as KeyValuePair<string, number>;
            });

            localStorage.setItem('currencyRates', JSON.stringify(rates));
        });
    }
    
    convertCurrency(mapperList: CurrencyConverterMapper): number {
        const currencyRateFrom = this.getCurrencyRates.find((x) => x.key === mapperList.currencyFrom);
        const currencyRateTo = this.getCurrencyRates.find((x) => x.key === mapperList.currencyTo);
        return currencyRateTo && currencyRateFrom ? mapperList.price * (currencyRateTo.value * (1 / currencyRateFrom.value)) : mapperList.price;
    }

    get getCurrencyRates(): KeyValuePair<string, number>[] {
        const rates: KeyValuePair<string, number>[] = JSON.parse(localStorage.getItem('currencyRates'));
        return rates;
    }

    convertCurrencyList(mapperList: CurrencyConverterMapper[], tries = 3): number {
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