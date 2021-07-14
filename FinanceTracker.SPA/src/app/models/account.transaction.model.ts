import { Transaction } from "./transaction.model";

export interface AccountTransaction {
    id: number;
    transaction: Transaction;
}