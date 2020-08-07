export interface User {
    id: number;
    userName: string;
    baseCurrency: string;
    age?: number;
    createdDate: Date;
    wallet: number;
    lastActive: Date;
    city: string;
    password: string;
    country: string;
}