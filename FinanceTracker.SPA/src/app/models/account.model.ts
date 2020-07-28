import { Transaction } from './transaction.model';
export interface Account {
    id?: number;
    bankId?: number;
    name: string;
    isActive: boolean;
    number: string;
    currentBalance: number;
    accountCurrency: string;
    createdDate?: Date;
    transactions: Transaction[];
}