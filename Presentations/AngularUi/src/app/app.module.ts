import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {ReactiveFormsModule} from '@angular/forms';
import {AppComponent} from './app.component';
import {TopBarComponent} from './core/components/top-bar/top-bar.component';
import {HttpClientModule} from '@angular/common/http';
import {AgGridModule} from 'ag-grid-angular';

@NgModule({
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            {path: '', component: TopBarComponent},
        ]),
        AgGridModule
    ],
    declarations: [
        AppComponent,
        TopBarComponent,
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {
}
