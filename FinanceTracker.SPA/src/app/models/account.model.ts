export interface Account {
    id: number;
    bankId: number;
    name: string;
    description: string;
    isActive: boolean;
    currentBalance: number;
    createdDate?: Date;
}