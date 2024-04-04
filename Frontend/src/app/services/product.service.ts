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
     public getProducts():Observable<any> {
     return this.http.get(`${environment.apiUrl}/${this.url}`);
  }
  public getProduct(id:number):Observable<product>{
    return this.http.get<product>(`${environment.apiUrl}/${this.url}/${id}`);
 }



  
  public updateProduct(product: product){
    return this.http.put( `${environment.apiUrl}/${this.url}/${product.id}`,product);
  }

  public createProduct(product: product) {
    return this.http.post(`${environment.apiUrl}/${this.url}`,product);
  }



  public deleteProduct(product: product){
    return this.http.delete(`${environment.apiUrl}/${this.url}/${product.id}`);
  }
  

}
