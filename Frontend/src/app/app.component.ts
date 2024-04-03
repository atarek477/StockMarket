import { Component } from '@angular/core';
import { product } from './models/product';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Frontend';
  Products: product[] = [];
  productToEdit?: product;

  constructor(private productservice: ProductService) {}

  ngOnInit(): void {
    this.productservice
      .getProducts()
      .subscribe((result: product[]) =>{
        this.Products = result;
        console.log('Products:', this.Products); 
      },
      error => {
        console.error('Error fetching products:', error);
      });

  }

  updateProductList(product: product[]) {
    this.Products = product;
  }

  initNewProduct() {
    this.productToEdit = new product();
  }

  editProduct(product: product) {
    this.productToEdit = product;
  }




}


