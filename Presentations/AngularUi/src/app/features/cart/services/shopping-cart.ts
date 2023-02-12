import {ShoppingCartItem} from "./shopping-cart-item";

export interface ShoppingCart {
    userId: number;
    items: ShoppingCartItem[];
}