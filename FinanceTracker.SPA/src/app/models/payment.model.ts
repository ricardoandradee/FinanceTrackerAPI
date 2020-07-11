export interface Payment {
    id: number;
    description?: string;
    address: string;
    establishment: string;
    categoryName?: string;
    categoryId?: number;
    currency: string;
    price: number;
    createdDateString?: string;
    createdDate?: Date;
}