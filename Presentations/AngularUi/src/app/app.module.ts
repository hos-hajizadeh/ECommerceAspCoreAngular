import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {ReactiveFormsModule} from '@angular/forms';
import {AppComponent} from './app.component';
import {TopBarComponent} from './core/components/top-bar/top-bar.component';
import {HttpClientModule} from '@angular/common/http';
import {AgGridModule} from 'ag-grid-angular';
import {ProductListComponent} from "./features/product/pages/product-list/product-list.component";
import {ButtonRendererComponent} from "./features/product/components/button-renderer.component";
import {ProductDetailsComponent} from './features/product/pages/product-details/product-details.component';

@NgModule({
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            {path: '', component: ProductListComponent},
            {path: 'products/:productId', component: ProductDetailsComponent},
        ]),
        AgGridModule
    ],
    declarations: [
        AppComponent,
        TopBarComponent,
        ProductListComponent,
        ButtonRendererComponent,
        ProductDetailsComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {
}
