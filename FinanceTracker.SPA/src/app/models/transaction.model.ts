import { Account } from './account.model';
export interface Transaction {
    id?: number;
    description: string;
    amount: number;
    action: string;
    balanceAfterTransaction: number;
    account: Account;
    createdDate?: Date;
}