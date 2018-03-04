import { Product } from './product';

// interface KeyValue {
//     Key: number;
//     Value: string;
// }

export interface Dish {
    Components: Product[];
    Description: string | null;
    Title: string;
    Id: string;
    State: number;
}
