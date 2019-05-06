import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';

const routes: Routes = [
  {
    path: '',
    data: { title: 'Product' },
    children: [
      { path: '', redirectTo: 'product-list' },
      { path: 'product-list', component: ProductListComponent, data: { title: 'List' } },
      { path: 'product-detail/:id', component: ProductDetailComponent, data: { title: 'Detail' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule {
  static components = [ProductListComponent, ProductDetailComponent];
}
