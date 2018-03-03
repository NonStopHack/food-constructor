import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Constants } from '../common/constants';
import { Observable } from 'rxjs/Observable';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'})
};

@Injectable()
export class FoodService {

  constructor(private http: HttpClient) { }

  getProducts(): Observable<any> {
    return this.http.get<any>(Constants.getProducts, httpOptions);
  }
}
