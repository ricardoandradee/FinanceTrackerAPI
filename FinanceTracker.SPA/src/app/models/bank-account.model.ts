import { Account } from 'src/app/models/account.model';
export interface BankAccount {
    id?: number;
    userId?: string;
    name: string;
    branch: string;
    isActive: boolean;
    createdDate?: Date;
    accounts: Account[];
    accountForCreation: Account;
}
