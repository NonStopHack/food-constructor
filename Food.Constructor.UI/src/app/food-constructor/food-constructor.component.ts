import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { FoodService } from '../services/food.service';
import { ServerResponse } from '../common/ServerResponse';
import { Product } from '../common/product';
import { NutritionalValue } from '../common/nutritional-value';
import { Constants } from '../common/constants';

@Component({
  selector: 'app-food-constructor',
  templateUrl: './food-constructor.component.html',
  styleUrls: ['./food-constructor.component.css']
})
export class FoodConstructorComponent implements OnInit {
  logoImg = Constants.Logo;
  products$: Observable<any>;
  products: Product[];
  indicators: NutritionalValue;
  dishParts: string[] = [];
  dishCategories: string[] = [];
  constructor(private foodService: FoodService) { }

  ngOnInit() {
    this.products$ = this.foodService.getProducts();
    this.products$.subscribe((p: ServerResponse) => {
      this.products = JSON.parse(p.Content);
    });
    this.indicators = {
      Proteins: 0,
      Fats: 0,
      Carbohydrates: 0,
      CaloricValue: 0
    };
    this.dishCategories.push('Smoothies');
    this.dishCategories.push('Burger');
  }

  newProductSelect(data) {
    const product: Product = data.product;
    const isSelect: boolean = data.isSelect;
    if (isSelect) {
      for (const key in this.indicators) {
        if (this.indicators.hasOwnProperty(key)) {
          this.indicators[key] += product.NutritionalValue[key];
        }
      }
      this.dishParts.push(product.Title);
    } else {
      for (const key in this.indicators) {
        if (this.indicators.hasOwnProperty(key)) {
          this.indicators[key] -= product.NutritionalValue[key];
        }
      }
      const indexToRemove = this.dishParts.indexOf(product.Title);
      if (indexToRemove > -1) {
        this.dishParts.splice(indexToRemove, 1);
      }
    }
  }

  selectCategory(dish) {
    this.dishCategories.forEach(d => document.getElementById('list-group-item-' + d).classList.remove('active'));
    document.getElementById('list-group-item-' + dish).classList.add('active');
    console.log(dish);
    this.products$ = this.foodService.getProductsByCategory(dish);
    this.products$.subscribe((p: ServerResponse) => {
      this.products = JSON.parse(p.Content);
    });
  }
}
