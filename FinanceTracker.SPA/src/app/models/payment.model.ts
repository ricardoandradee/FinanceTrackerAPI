export interface Payment {
    id: number;
    description?: string;
    address: string;
    establishment: string;
    categoryName?: string;
    categoryId?: number;
    currency: string;
    status?: 'Paid' | 'Unpaid' | 'Partial';
    price: number;
    createdDateString?: string;
    createdDate?: Date;
}