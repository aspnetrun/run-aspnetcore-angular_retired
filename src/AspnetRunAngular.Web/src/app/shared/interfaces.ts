export interface IProduct {
    id: number;
    name: string;
    description: string;
    unitPrice: number;
    category: ICategory;
    status: IProductStatus;
}

export interface ICategory {
    id: number;
    name?: string;
    description?: string;
}

export interface IProductStatus {
    id: number;
    code?: string;
    name?: string;
}
