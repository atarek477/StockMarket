import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent implements OnInit{
  @Input() product?: product; // Ensure Product is the correct type
  @Output() productUpdated = new EventEmitter<product[]>(); // Ensure Product is the correct type

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    // Add initialization logic here if needed
  }

  updateProduct(updatedProduct: product) {
    this.productService.updateProduct(updatedProduct)
      .subscribe((products: product[]) => this.productUpdated.emit(products));
  }

  deleteProduct(deletedProduct: product) {
    this.productService.deleteProduct(deletedProduct)
      .subscribe((products: product[]) => this.productUpdated.emit(products));
  }

  createProduct(newProduct: product) {
    this.productService.createProduct(newProduct)
      .subscribe((products: product[]) => this.productUpdated.emit(products));
  }

}
