import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {ProductService} from "../../services/product.service";
import {Product} from "../../../../core/models/products";
import {CartService} from "../../../cart/services/cart.service";

@Component({
    selector: 'app-product-details',
    templateUrl: './product-details.component.html',
    styleUrls: ['./product-details.component.css']
})

export class ProductDetailsComponent implements OnInit {

    product: Product | undefined;

    constructor(private productService: ProductService, private route: ActivatedRoute, private cartService: CartService) {

    }

    ngOnInit() {
        const routeParams = this.route.snapshot.paramMap;
        const productIdFromRoute = Number(routeParams.get('productId'));

        this.productService.get(productIdFromRoute)
            .subscribe(
                data => {
                    this.product = data;
                    console.log(data);
                },
                error => {
                    console.log(error);
                });
    }

    addToCart(product: Product) {
        this.cartService.addToCart(product).toPromise().then();
    }
}
