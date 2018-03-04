import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { FoodService } from '../services/food.service';
import { ServerResponse } from '../common/server-response';
import { Product } from '../common/product';
import { NutritionalValue } from '../common/nutritional-value';
import { Constants } from '../common/constants';
import { Subscription } from 'rxjs/Subscription';
import { Order } from '../common/Order';
import { Dish } from '../common/Dish';

@Component({
  selector: 'app-food-constructor',
  templateUrl: './food-constructor.component.html',
  styleUrls: ['./food-constructor.component.css']
})
export class FoodConstructorComponent implements OnInit, OnDestroy {

  logoImg = Constants.Logo;
  products$: Observable<ServerResponse>;
  productsSub: Subscription;
  products: Product[];
  indicators: NutritionalValue;
  dishParts: Product[] = [];
  dishes: Dish[] = [];
  dishCategories: string[] = [];
  constructor(private foodService: FoodService) { }

  ngOnInit() {
    this.products$ = this.foodService.getProducts();
    this.productsSub = this.products$.subscribe((p: ServerResponse) => {
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

  ngOnDestroy(): void {
    this.productsSub.unsubscribe();
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
      this.dishParts.push(product);
    } else {
      for (const key in this.indicators) {
        if (this.indicators.hasOwnProperty(key)) {
          this.indicators[key] -= product.NutritionalValue[key];
        }
      }
      const indexToRemove = this.dishParts.indexOf(product);
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
    this.productsSub = this.products$.subscribe((p: ServerResponse) => {
      this.products = JSON.parse(p.Content);
    });
  }

  makeOrder() {
    const dishes2: Dish[] = [{
      Description: 'Description',
      Id: '00000000-0000-0000-0000-000000000000',
      State: 1,
      // History: null,
      Title: 'Dish title',
      Components: this.dishParts
    }];

    const order: Order = {
     CompanyId: '00000000-0000-0000-0000-000000000000',
     History: [{Key: 0, Value: ''}],
     State: 0,
     Id: '00000000-0000-0000-0000-000000000000',
     CustomerId: '00000000-0000-0000-0000-000000000000',
     IssuePointId: '00000000-0000-0000-0000-000000000000',
     Dishes: dishes2
    };

    this.foodService.createOrUpdateOrder(order);
  }
}
