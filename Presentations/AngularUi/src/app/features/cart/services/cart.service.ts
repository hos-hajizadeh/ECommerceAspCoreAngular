import {Injectable} from '@angular/core';
import {Observable, of} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {ShoppingCartItem} from "./shopping-cart-item";
import {ShoppingCart} from "./shopping-cart";
import {Constants} from "../../../core/constants/constants";
import {Product} from "../../../core/models/products";

const baseUrl = Constants.shoppingCartBaseUrl;

@Injectable({
    providedIn: 'root'
})
export class CartService {
    items: ShoppingCartItem[] = [];

    constructor(private http: HttpClient) {
    }

    getItems(): Observable<any> {
        if (this.items !== null && this.items.length > 0)
            return of(this.items);

        return new Observable<ShoppingCartItem[]>(observer => {
            this.http.get<ShoppingCart>(`${baseUrl}`).subscribe(
                (data) => {
                    this.items = data.items;
                    console.log(data);
                    observer.next(this.items);
                },
                error => {
                    console.log(error);
                    observer.error(error);
                });
        });
    }

    addToCart(product: Product): Observable<any> {
        return new Observable<ShoppingCartItem[]>(observer => {
            this.http.post(`${baseUrl}`, {
                ProductId: product.id,
                Quantity: 1
            }).subscribe(
                (data) => {
                    this.items = [];
                    window.alert("addToCart was success")
                    console.log(data);
                    observer.next(this.items);
                },
                error => {
                    console.log(error);
                    observer.error(error);
                });
        });
    }

    deleteItemFromCart(item: ShoppingCartItem): Observable<any> {
        return new Observable<ShoppingCartItem[]>(observer => {
            this.http.delete(`${baseUrl}/${item.productOverview.id}`).subscribe(
                (data) => {
                    this.items = [];
                    window.alert("delete Item From Cart was success")
                    console.log(data);
                    observer.next(this.items);
                },
                error => {
                    console.log(error);
                    observer.error(error);
                });
        });
    }
    
    clearCart() {
        this.items = [];
        return this.items;
    }

}

