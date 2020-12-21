import {Component, OnInit} from '@angular/core';
import {ApiIngredientService} from '../../core/_services/api.ingredient.service';

@Component({
  selector: 'app-ingredient',
  templateUrl: './ingredient.component.html',
  styleUrls: ['./ingredient.component.scss'],
  providers: [ApiIngredientService]
})
export class IngredientComponent implements OnInit {
  ingredients: any;
  search = {
    name: ''
  };

  constructor(
    private apiIngredientService: ApiIngredientService
  ) {
  }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.apiIngredientService.getItems()
      .subscribe((data) => {
        this.ingredients = data;
      });
  }

  delete(id) {
    this.apiIngredientService.deleteItem(id)
      .subscribe((data) => {
        this.getData();
      });
  }

  s(data) {
    return JSON.stringify(data);
  }
}
