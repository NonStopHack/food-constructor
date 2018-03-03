import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-product-picker',
  templateUrl: './product-picker.component.html',
  styleUrls: ['./product-picker.component.css']
})
export class ProductPickerComponent implements OnInit {
  @Input() product;
  filter = false;
  constructor() { }

  ngOnInit() {
  }

  filterData(data) {
    this.filter = !this.filter;
    console.log(data);
  }

  onCheck(event, data) {
    console.log(event);
    console.log(data);
  }

}
