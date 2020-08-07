export interface User {
    id: number;
    userName: string;
    baseCurrency: string;
    age?: number;
    dateOfBirth?: Date;
    createdDate: Date;
    wallet: number;
    lastActive: Date;
    timeZone: string;
    password: string;
    country: string;
}