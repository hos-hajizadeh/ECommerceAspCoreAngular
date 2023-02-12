import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {CartService} from '../../services/cart.service';
import {ShoppingCartItem} from "../../services/shopping-cart-item";
import {CheckOutService} from "../../../check-out/services/check-out.service";

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
    items: ShoppingCartItem[] = [];
    submitted = false;

    checkoutForm = this.formBuilder.group({
        name: ['', Validators.required],
        address: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
    });

    get f(): { [key: string]: AbstractControl } {
        return this.checkoutForm.controls;
    }

    constructor(private cartService: CartService, private formBuilder: FormBuilder, private checkOutService: CheckOutService
    ) {
    }

    ngOnInit(): void {
        this.cartService.getItems()
            .subscribe(
                data => {
                    this.items = data;
                    console.log(data);
                },
                error => {
                    console.log(error);
                });
    }

    delete(item: ShoppingCartItem): void {
        this.cartService.deleteItemFromCart(item)
            .subscribe(
                data => {
                    this.ngOnInit();
                },
                error => {
                    console.log(error);
                });
    }

    onSubmit(): void {
        this.submitted = true;

        if (this.checkoutForm.invalid)
            return;

        this.checkOutService.purchase(this.checkoutForm.value).subscribe(
            data => {
                this.cartService.clearCart();
                this.ngOnInit();
                window.alert("Purchase was success")
            },
            error => {
                console.log(error);
            });
    }
}