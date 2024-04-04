import { Component } from '@angular/core';
import { product } from './models/product';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Frontend';;;
 
  list: product[] = [];
  constructor(private productService:ProductService) {}

  

}


