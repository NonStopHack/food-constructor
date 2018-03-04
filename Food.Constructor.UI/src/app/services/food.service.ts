import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Constants } from '../common/constants';
import { Observable } from 'rxjs/Observable';
import { ServerResponse } from '../common/ServerResponse';
import { Order } from '../common/Order';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'})
};

@Injectable()
export class FoodService {

  constructor(private http: HttpClient) { }

  getProducts(): Observable<ServerResponse> {
    return this.http.get<ServerResponse>(Constants.getProducts, httpOptions);
  }

  getProductsByCategory(category: string): Observable<ServerResponse> {
    return this.http.get<ServerResponse>(Constants.getProducts + '?category=' + category, httpOptions);
  }

  createOrUpdateOrder(order: Order) {
    return this.http.post(Constants.createOrUpdateOrder, order, httpOptions);
  }
}
