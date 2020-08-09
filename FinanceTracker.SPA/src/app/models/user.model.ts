import { Currency } from './currency.model';

export interface User {
    id: number;
    userName: string;
    email: string;
    currency: Currency;
    createdDate: Date;
    wallet: number;
    lastActive: Date;
    timeZoneUtc: string;
    stateTimeZoneId: string;
    password: string;
    country: string;
}