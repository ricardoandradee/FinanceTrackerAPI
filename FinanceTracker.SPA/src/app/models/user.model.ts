export interface User {
    id: number;
    userName: string;
    baseCurrency: string;
    createdDate: Date;
    wallet: number;
    lastActive: Date;
    timeZoneUtc: string;
    stateTimeZoneId: string;
    password: string;
    country: string;
}