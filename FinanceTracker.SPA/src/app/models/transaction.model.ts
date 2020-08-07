import { Account } from './account.model';
export interface Transaction {
    id?: number;
    description: string;
    amount: number;
    action: 'Deposit' | 'Withdraw';
    balanceAfterTransaction: number;
    account: Account;
    createdDate?: Date;
}