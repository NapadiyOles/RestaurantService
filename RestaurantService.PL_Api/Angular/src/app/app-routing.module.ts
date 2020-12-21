import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './pages/home/home.component';
import {MenuComponent} from './pages/menu/menu.component';
import {MenuDetailsComponent} from './pages/menu/menu-details/menu-details.component';
import {OrdersComponent} from './pages/orders/orders.component';
import {OrderDetailsComponent} from './pages/orders/order-details/order-details.component';
import {OrderEditComponent} from './pages/orders/order-edit/order-edit.component';
import {ReceipesComponent} from './pages/receipes/receipes.component';
import {RecipeDetailsComponent} from './pages/receipes/recipe-details/recipe-details.component';
import {ReceipeEditComponent} from './pages/receipes/receipe-edit/receipe-edit.component';
import {IngredientComponent} from './pages/ingredient/ingredient.component';
import {IngredientDetailsComponent} from './pages/ingredient/ingredient-details/ingredient-details.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'menu', component: MenuComponent
  },
  {
    path: 'menu/:id', component: MenuDetailsComponent
  },
  {
    path: 'orders', component: OrdersComponent
  },
  {
    path: 'order-details/:id', component: OrderDetailsComponent
  },
  {
    path: 'order-edit/:id', component: OrderEditComponent
  },
  {
    path: 'recipes', component: ReceipesComponent
  },
  {
    path: 'recipes-details/:id', component: RecipeDetailsComponent
  },
  {
    path: 'recipes-edit/:id', component: ReceipeEditComponent
  },
  {
    path: 'ingredients', component: IngredientComponent
  },
  {
    path: 'ingredient-edit/:id', component: IngredientDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
