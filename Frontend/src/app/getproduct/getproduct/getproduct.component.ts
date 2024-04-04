import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { product } from '../../models/product';

@Component({
  selector: 'app-getproduct',
  templateUrl: './getproduct.component.html',
  styleUrl: './getproduct.component.css'
})
export class GetproductComponent implements OnInit{
  
  constructor(private productService: ProductService) { }
  
  
  list: product[] = [];
  id:product | undefined;

  ngOnInit(): void {
    this.get();
  }

  get(){
this.productService.getProducts().subscribe(products => {
  this.list = products});

  }
  delete(product:product){
    this.productService.deleteProduct(product).subscribe(()=>{this.get()});
    
      }


}
