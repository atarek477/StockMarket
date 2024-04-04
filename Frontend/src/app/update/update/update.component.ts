import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { product } from '../../models/product';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent implements OnInit {

  updateProduct: product = new product(); 
  id:any
  constructor(private act : ActivatedRoute,private productService: ProductService,private route:Router) { }
  ngOnInit(): void {
      this.id=this.act.snapshot.paramMap.get('id');
     
      this.productService.getProduct(this.id).subscribe(res=>{this.updateProduct=res},err=>{
        console.log(err)
      }); 
      
  }


  update(){
    console.log(this.updateProduct.id)
    console.log(this.updateProduct.name)
    
   

  this.productService.updateProduct(this.updateProduct).subscribe(res => {this.route.navigate(['/getproduct']);
  }, error => {
    console.log(error);
  });

  }





}
