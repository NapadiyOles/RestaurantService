import {Component, OnInit} from '@angular/core';
import {ApiReceipeService} from '../../../core/_services/api.receipe.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.scss'],
  providers: [ApiReceipeService]
})
export class RecipeDetailsComponent implements OnInit {
  data: any;

  constructor(
    private apiReceipeService: ApiReceipeService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.apiReceipeService.getItemsParams(this.route.snapshot?.paramMap?.get('id')?.toString() || '')
      .subscribe((data) => {
        this.data = data;
      });
  }

}
