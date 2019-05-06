import { Component } from '@angular/core';
import { ProductDataService } from 'src/app/core/services/product-data.service';
import { ActivatedRoute } from '@angular/router';
import { DataGridOptions } from 'src/app/shared/data-grid/data-grid.utils';
import { IProduct } from 'src/app/shared/interfaces';

@Component({
  selector: 'ke-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  gridOptions: DataGridOptions = {
    columnDefs: [
      { prop: 'name', name: 'Name', sortable: false },
      { prop: 'description', name: 'Description', sortable: false },
      { prop: 'unitPrice', name: 'Unit Price', sortable: false },
      { prop: 'category.description', name: 'Category', sortable: false },
      { prop: 'status.name', name: 'Status', sortable: false },
    ],
    data: [],
    pageOffset: {
      count: 9999,
      limit: 9999,
      offset: 1
    },
    detailPageUrl: '/product/product-detail'
  };

  constructor(private dataService: ProductDataService, route: ActivatedRoute) {
    route.params.subscribe(() => {
      this.getProducts();
    });
  }


  getProducts() {
    this.dataService.getProducts().subscribe((product: IProduct[]) => {
      this.gridOptions.data = product;
    });
  }
}
