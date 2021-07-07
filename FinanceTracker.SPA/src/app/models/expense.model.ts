import { Currency } from './currency.model';
import { Category } from './category.model';

export interface Expense {
    id: number;
    description?: string;
    establishment: string;
    category?: Category;
    currency: Currency;
    status?: 'Paid' | 'Unpaid' | 'Partial';
    price: number;
    createdDateString?: string;
    createdDate?: Date;
}