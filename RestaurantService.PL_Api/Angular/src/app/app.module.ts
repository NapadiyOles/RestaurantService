import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HomeComponent} from './pages/home/home.component';
import {MenuComponent} from './pages/menu/menu.component';
import {HttpClientModule} from '@angular/common/http';
import {ApiBaseService} from './core/_services/api.base.service';
import {MenuDetailsComponent} from './pages/menu/menu-details/menu-details.component';
import {OrdersComponent} from './pages/orders/orders.component';
import {OrderDetailsComponent} from './pages/orders/order-details/order-details.component';
import {OrderEditComponent} from './pages/orders/order-edit/order-edit.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {ReceipesComponent} from './pages/receipes/receipes.component';
import {RecipeDetailsComponent} from './pages/receipes/recipe-details/recipe-details.component';
import {FilterPipeModule} from 'ngx-filter-pipe';
import { ReceipeEditComponent } from './pages/receipes/receipe-edit/receipe-edit.component';
import { IngredientComponent } from './pages/ingredient/ingredient.component';
import { IngredientDetailsComponent } from './pages/ingredient/ingredient-details/ingredient-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    MenuDetailsComponent,
    OrdersComponent,
    OrderDetailsComponent,
    OrderEditComponent,
    ReceipesComponent,
    RecipeDetailsComponent,
    ReceipeEditComponent,
    IngredientComponent,
    IngredientDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FilterPipeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
