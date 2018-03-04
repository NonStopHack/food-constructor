import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../../common/product';

@Component({
  selector: 'app-product-picker',
  templateUrl: './product-picker.component.html',
  styleUrls: ['./product-picker.component.css']
})
export class ProductPickerComponent implements OnInit {
  @Input() product;
  @Output() selectedProduct: EventEmitter<any> = new EventEmitter();
  filter = false;
  constructor() { }

  ngOnInit() {
  }

  filterData(product: Product) {
    this.filter = !this.filter;
    this.selectedProduct.emit({product: product, isSelect: this.filter});
  }

}
