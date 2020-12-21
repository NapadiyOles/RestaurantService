import {Component, OnInit} from '@angular/core';
import {ApiReceipeService} from '../../core/_services/api.receipe.service';

@Component({
  selector: 'app-receipes',
  templateUrl: './receipes.component.html',
  styleUrls: ['./receipes.component.scss'],
  providers: [ApiReceipeService]
})
export class ReceipesComponent implements OnInit {
  receipes: any;

  constructor(
    private apiReceipeService: ApiReceipeService
  ) {
  }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.apiReceipeService.getItems()
      .subscribe((data) => {
        this.receipes = data;
      });
  }

  delete(id: number) {
    this.apiReceipeService.deleteItem(id)
      .subscribe((data) => {
        this.getData();
      });
  }
}
