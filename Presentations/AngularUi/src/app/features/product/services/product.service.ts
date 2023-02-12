import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Constants} from "../../../core/constants/constants";

const baseUrl = Constants.productBaseUrl;

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    constructor(private http: HttpClient) {
    }

    getAll(): Observable<any> {
        return this.http.get(baseUrl);
    }

    get(id: number): Observable<any> {
        return this.http.get(`${baseUrl}/${id}`);
    }
}
