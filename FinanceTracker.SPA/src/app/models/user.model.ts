export interface User {
    id: number;
    userName: string;
    email: string;
    baseCurrency: string;
    createdDate: Date;
    wallet: number;
    lastActive: Date;
    timeZoneUtc: string;
    stateTimeZoneId: string;
    password: string;
    country: string;
}