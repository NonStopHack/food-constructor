import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { FoodService } from '../services/food.service';
import { ServerResponse } from '../common/ServerResponse';
import { Product } from '../common/product';


@Component({
  selector: 'app-food-constructor',
  templateUrl: './food-constructor.component.html',
  styleUrls: ['./food-constructor.component.css']
})
export class FoodConstructorComponent implements OnInit {

  // products = [{title: '1'}, {title: '2'}, {title: '3'}];
  products: Product[];
  constructor(private foodService: FoodService) { }

  ngOnInit() {
    this.foodService.getProducts().subscribe((p: ServerResponse) => {
      this.products = JSON.parse(p.Content);
    });

    // this.products.subscribe(p => {
    //   console.log(p);
    // });
  }

}
