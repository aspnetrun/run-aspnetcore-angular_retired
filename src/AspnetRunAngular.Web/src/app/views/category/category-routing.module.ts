import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';

const routes: Routes = [
  {
    path: '',
    data: { title: 'Category' },
    children: [
      { path: '', redirectTo: 'category-list' },
      { path: 'category-list', component: CategoryListComponent, data: { title: 'List' } },
      { path: 'category-detail/:id', component: CategoryDetailComponent, data: { title: 'Detail' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule {
  static components = [CategoryListComponent, CategoryDetailComponent];
}
