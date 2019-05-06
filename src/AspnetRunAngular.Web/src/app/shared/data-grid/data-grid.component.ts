import { Component, Input, Output, EventEmitter } from '@angular/core';
import { DataGridOptions, Sort, PageOffset } from './data-grid.utils';
import * as _ from 'lodash';

@Component({
  selector: 'data-grid',
  templateUrl: './data-grid.component.html',
  styleUrls: ['./data-grid.component.css']
})
export class DataGridComponent {
  lodash = _;
  @Input() gridOptions: DataGridOptions;
  loading: boolean;
  @Output() pageChanged: EventEmitter<PageOffset> = new EventEmitter<PageOffset>();
  @Output() sortChanged: EventEmitter<Sort[]> = new EventEmitter<Sort[]>();

  onPageChanged(event: PageOffset) {
    this.pageChanged.emit(event);
  }

  onSortChanged(event: { sorts: Sort[] }) {
    this.sortChanged.emit(event.sorts);
  }
}
