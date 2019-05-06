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

export interface IProductsSearchArgs {
    pagingArgs: IPagingArgs;
    sortColumns: ISortColumn[];
}

export interface IPagingArgs {
    pageSize: number;
    currentPage: number;
    pagingStrategy: PagingStrategy;
}

export enum PagingStrategy {
    NoCount = 0,
    WithCount = 1,
}

export interface IPage<T> {
    currentPage: number;
    pageSize: number;
    totalPages: number;
    totalItems: number;
    hasMore: boolean;
    items: T[];
}

export interface ISortColumn {
    name: string;
    direction: SortDirection;
    priority: number;
}

export enum SortDirection {
    Asc = 1,
    Desc = -1
}
