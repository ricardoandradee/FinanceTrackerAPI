export interface BankAccount {
    id: number;
    userId: string;
    name: string;
    address: string;
    branch: string;
    isActive: boolean;
    createdDate?: Date;
    accounts: Account[];
}