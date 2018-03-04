import { NutritionalValue } from './nutritional-value';

export interface Product {
    Id: string;
    Measurement: number;
    Quantity: number;
    Title: string;
    NutritionalValue: NutritionalValue;
    ImageBase64: string;
}
