import { Currency } from './currency.model';
import { Category } from './category.model';
import { Transaction } from './transaction.model';

export interface Expense {
    id: number;
    establishment: string;
    category?: Category;
    currency: Currency;
    price: number;
    isPaid: boolean;
    createdDateString?: string;
    createdDate?: Date;
    transaction?: Transaction;
}