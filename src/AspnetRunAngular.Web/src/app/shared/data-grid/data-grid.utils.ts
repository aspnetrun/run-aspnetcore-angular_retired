export interface DataGridOptions {
    columnDefs: ColumnDef[];
    data: any[];
    pageOffset: PageOffset;
    detailPageUrl: string;
}

interface ColumnDef {
    prop: string;
    name: string;
    filter?: string;
    filterFormat?: string;
    sortable?: boolean;
    width?: number;
    cellClass?(row): any;
}

export interface PageOffset {
    count: number; //totalItems
    limit: number;
    //pageSize: number;
    offset: number; //currentPage
}

export interface Sort {
    prop: string;
    dir: string; // desc, asc
}
