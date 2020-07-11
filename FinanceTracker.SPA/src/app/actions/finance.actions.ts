import { Action } from '@ngrx/store';
import { Payment } from '../models/payment.model';
import { Category } from '../models/category.model';

export const SET_PAYMENT_HISTORY = '[Payment] Set Payment History';
export const SET_CATEGORIES = '[Category] Set All Categories';
export const SET_USER_BASE_CURRENCY = '[User] Set User Base Currency';

export class SetPaymentHistory implements Action {
    readonly type = SET_PAYMENT_HISTORY;
    constructor(public payload: Payment[]) {
    }
}

export class SetCategories implements Action {
    readonly type = SET_CATEGORIES;
    constructor(public payload: Category[]) {
    }
}

export class SetUserBaseCurrency implements Action {
    readonly type = SET_USER_BASE_CURRENCY;
    constructor(public payload: string) {
    }
}

export type FinanceActions = SetPaymentHistory | SetCategories | SetUserBaseCurrency;
