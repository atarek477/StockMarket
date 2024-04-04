import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { GetproductComponent } from './getproduct/getproduct/getproduct.component';
import { UpdateComponent } from './update/update/update.component';

const routes: Routes = [
  { path: 'edit', component: EditProductComponent } ,
  { path: 'getproduct', component: GetproductComponent } ,
  { path: 'update/:id', component: UpdateComponent } 




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
