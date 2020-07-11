import { FinanceActions, SET_PAYMENT_HISTORY, SET_CATEGORIES } from '../actions/finance.actions';

import * as fromRoot from 'src/app/reducers/app.reducer';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { Payment } from '../models/payment.model';
import { Category } from '../models/category.model';

export interface FinanceState {
    paymentHistory: Payment[];
    categories: Category[];
}

export interface State extends fromRoot.State {
    finance: FinanceState;
}

const initialState: FinanceState = {
    paymentHistory: [],
    categories: []
};

export function financeReducer(state = initialState, action: FinanceActions) {
    switch (action.type) {
        case SET_PAYMENT_HISTORY:
            return { ...state, paymentHistory: action.payload };
        case SET_CATEGORIES:
            return { ...state, categories: action.payload };
        default: { return state; }
    }
}

export const getFinanceState = createFeatureSelector<FinanceState>('finance');

export const getPaymentHistory = createSelector(getFinanceState, (state: FinanceState) => state.paymentHistory);
export const getAllCategories = createSelector(getFinanceState, (state: FinanceState) => state.categories);