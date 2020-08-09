export interface User {
    id: number;
    userName: string;
    baseCurrency: string;
    age?: number;
    dateOfBirth?: Date;
    createdDate: Date;
    wallet: number;
    lastActive: Date;
    timeZoneUtc: string;
    stateTimeZoneId: string;
    password: string;
    country: string;
}