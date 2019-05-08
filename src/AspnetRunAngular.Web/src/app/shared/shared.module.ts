import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ControlMessageComponent } from './control-messages/control-message.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';
import { DataGridComponent } from './data-grid/data-grid.component';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    NgxDatatableModule,
    ModalModule.forRoot(),
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule,
    ControlMessageComponent,
    DataGridComponent,
  ],
  declarations: [
    ControlMessageComponent,
    DataGridComponent,
  ]
})
export class SharedModule { }
