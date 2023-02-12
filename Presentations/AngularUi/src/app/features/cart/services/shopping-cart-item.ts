import {ProductOverview} from "../../../core/models/product-overview";

export interface ShoppingCartItem {
    id: number;
    quantity: number;
    productOverview: ProductOverview;
}
 
 