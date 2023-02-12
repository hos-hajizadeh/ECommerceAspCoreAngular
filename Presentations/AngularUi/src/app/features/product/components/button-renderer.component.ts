import {Component} from '@angular/core';
import {ICellRendererAngularComp} from 'ag-grid-angular';
import {ICellRendererParams} from "ag-grid-community";
@Component({
    selector: 'app-button-renderer',
    template: `<span><button (click)="buttonClicked()">Buy</button></span>`
})
export class ButtonRendererComponent implements ICellRendererAngularComp {
    params:any;
    
    agInit(params: ICellRendererParams): void {
        this.params=params;
    }
    refresh(params: ICellRendererParams): boolean {
        return true;
    }
    buttonClicked() {
        if (this.params.onClick instanceof Function) {
            const params = {
                rowData: this.params.node.data
            }
            this.params.onClick(params);
        }
    }
}
 