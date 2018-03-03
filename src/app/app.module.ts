import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ProductPickerComponent } from './food-constructor/product-picker/product-picker.component';
import { FoodConstructorComponent } from './food-constructor/food-constructor.component';
import { FoodService } from './services/food.service';
import { IndicatorsComponent } from './food-constructor/indicators/indicators.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductPickerComponent,
    FoodConstructorComponent,
    IndicatorsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [FoodService],
  bootstrap: [AppComponent]
})
export class AppModule { }
