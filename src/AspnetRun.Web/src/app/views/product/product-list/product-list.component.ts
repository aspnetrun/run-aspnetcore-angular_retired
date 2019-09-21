import { Component, OnInit } from '@angular/core';
import { ProductDataService } from 'src/app/core/services/product-data.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/interfaces';

@Component({
  selector: 'ke-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  
  products: IProduct[];
  //productName: string = '';

  _productName: string = '';
  get productName(): string {
    return this._productName;
  }
  set productName(value: string) {
    this._productName = value;
    this.getProducts();
  }

  constructor(private dataService: ProductDataService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(() => {
      this.getProducts();
    });
  }

  getProducts() {
    this.dataService.getProductsByName(this.productName).subscribe((products: IProduct[]) => {
        this.products = products;
      });
  }

}
