export interface Category {
    id: number;
    userId: string;
    name: string;
    description: string;
    createdDate?: Date;
    canBeDeleted: Boolean;
}