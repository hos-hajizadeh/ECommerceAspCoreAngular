import {Component, OnInit} from '@angular/core';
import {ProductService} from "../../services/product.service";
import {Product} from "../../services/products";
import {ButtonRendererComponent} from "../../components/button-renderer.component";
import { Router } from '@angular/router';

@Component({
    selector: 'app-product-list',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    constructor(private productService: ProductService, private router: Router) {
        this.frameworkComponents = {
            buttonRenderer: ButtonRendererComponent,
        }
    }

    products: Product[] = [];
    frameworkComponents: any;

    columnDefs = [
        {headerName: 'name', field: 'name'},
        {headerName: 'Description', field: 'description'},
        {headerName: 'Price', field: 'price'},
        {
            headerName: 'Buy',
            cellRenderer: 'buttonRenderer',
            cellRendererParams: {
                onClick: this.onBtnClick.bind(this),
                label: 'Buy'
            }
        },
    ];

    rowData = [];
    defaultColDef = {
        sortable: true,
        filter: true
    };

    ngOnInit(): void {
        this.retrieve();
    }

    retrieve(): void {
        this.productService.getAll()
            .subscribe(
                data => {
                    this.products = data;
                    this.rowData = data;
                    console.log(data);
                },
                error => {
                    console.log(error);
                });
    }

    onBtnClick(row:any): void {
        this.router.navigate(['/products/'+row.rowData.id])
    }
}
 