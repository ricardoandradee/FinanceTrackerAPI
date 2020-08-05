import { Pipe, PipeTransform } from '@angular/core';
import { Payment } from '../models/payment.model';
import { CurrencyConverterMapper } from '../models/currency.converter.mapper.model';
import { CurrencyService } from '../services/currency.service';

@Pipe({
  name: 'paymentTotalPrice'
})
export class PaymentTotalPricePipe implements PipeTransform {
    constructor(public currencyService: CurrencyService) { }

    transform(items: Payment[], userBaseCurrency: string): number {
        const allCurrenciesToConvert = items.map(x => x.currency);
        if (this.currencyService.checkIfCurrenciesAreLoaded(allCurrenciesToConvert)) {
        const currencyMapperList = items.map((payment: Payment) => {
            return { currencyFrom: payment.currency, currencyTo: userBaseCurrency, price: payment.price } as CurrencyConverterMapper;
        });
        return this.currencyService.convertCurrencyList(currencyMapperList);
        }
    }
}