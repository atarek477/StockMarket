import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { error } from 'console';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent implements OnInit {
 

  constructor(private productService: ProductService) { }

  newProduct: product = new product();


  create(productnew:product){

  this.productService.createProduct(productnew).subscribe(res=>{console.log(res)},err=>{err});



  }


  ngOnInit(): void {

  }



}
