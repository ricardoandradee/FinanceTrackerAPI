import { Currency } from './currency.model';
import { Category } from './category.model';

export interface Expense {
    id: number;
    establishment: string;
    category?: Category;
    accountId?: number;
    currency: Currency;
    status?: 'Paid' | 'Unpaid' | 'Partial';
    price: number;
    amountPaid?: number;
    createdDateString?: string;
    createdDate?: Date;
}