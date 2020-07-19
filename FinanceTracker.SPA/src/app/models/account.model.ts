export interface Account {
    id?: number;
    bankId?: number;
    name: string;
    description: string;
    isActive: boolean;
    number: string;
    currentBalance: number;
    accountCurrency: string;
    createdDate?: Date;
}