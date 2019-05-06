import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { ProductDataService } from './services/product-data.service';
import { ValidationService } from './services/validation.service';
import { EnsureModuleLoadedOnceGuard } from './ensure-module-loaded-once.guard';
import { HttpErrorInterceptor } from './interceptors/http-error.interceptor';
import { NgxUiLoaderModule, NgxUiLoaderHttpModule } from 'ngx-ui-loader';
import { SpinnerService } from './services/spinner.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    NgxUiLoaderModule,
    //NgxUiLoaderRouterModule, // import this module for showing loader automatically when navigating between app routes
    NgxUiLoaderHttpModule.forRoot({ showForeground: true }),
  ],
  exports: [
    RouterModule,
    HttpClientModule,
    NgxUiLoaderModule,
  ],
  providers: [
    ProductDataService,
    ValidationService,
    SpinnerService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    },
  ] // these should be singleton
})
export class CoreModule extends EnsureModuleLoadedOnceGuard {    // Ensure that CoreModule is only loaded into AppModule

  // Looks for the module in the parent injector to see if it's already been loaded (only want it loaded once)
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    super(parentModule);
  }
}
