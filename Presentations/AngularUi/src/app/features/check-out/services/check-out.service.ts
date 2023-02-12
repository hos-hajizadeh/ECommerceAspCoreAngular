import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Constants} from "../../../core/constants/constants";

const baseUrl = Constants.purchaseBaseUrl;

@Injectable({
    providedIn: 'root'
})
export class CheckOutService {

    constructor(private http: HttpClient) {
    }

    purchase(data: any) {
        return this.http.post(`${baseUrl}`, data);
    }
}
