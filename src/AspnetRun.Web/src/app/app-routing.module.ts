import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'product', pathMatch: 'full', },
  { path: 'index', redirectTo: 'product', pathMatch: 'full', },
  { path: 'product', loadChildren: () => import('./views/product/product.module').then(m => m.ProductModule) },
  { path: 'category', loadChildren: () => import('./views/category/category.module').then(m => m.CategoryModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules, enableTracing: false })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
