export interface IProduct {
    id: string;
    name: string;
    description: string;
    unitPrice: number;
    category: ICategory;
    status: IProductStatus;
}

export interface ICategory {
    id: string;
    name?: string;
    description?: string;
}

export interface IProductStatus {
    id: number;
    code?: string;
    name?: string;
}
