import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header/header.component';
import { GetproductComponent } from './getproduct/getproduct/getproduct.component';
import { UpdateComponent } from './update/update/update.component';

@NgModule({
  declarations: [
    AppComponent,
    EditProductComponent,
    HeaderComponent,
    GetproductComponent,
    UpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }