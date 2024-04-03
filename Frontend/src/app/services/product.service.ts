import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { product } from '../models/product';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
   url="Product"
     constructor(private http: HttpClient) {}
     public getProducts(): Observable<product[]> {
     return this.http.get<product[]>(`${environment.apiUrl}/${this.url}`);
  }


  
  public updateProduct(product: product): Observable<product[]> {
    return this.http.put<product[]>(
      `${environment.apiUrl}/${this.url}/${product.id}`,
      product
    );
  }

  public createProduct(product: product): Observable<product[]> {
    return this.http.post<product[]>(
      `${environment.apiUrl}/${this.url}`,
      product
    );
  }



  public deleteProduct(product: product): Observable<product[]> {
    return this.http.delete<product[]>(
      `${environment.apiUrl}/${this.url}/${product.id}`
    );
  }
  

}
