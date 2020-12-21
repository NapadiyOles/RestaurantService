import {Component, OnInit} from '@angular/core';
import {ApiMenuService} from '../../../core/_services/api.menu.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-menu-details',
  templateUrl: './menu-details.component.html',
  styleUrls: ['./menu-details.component.scss'],
  providers: [ApiMenuService]
})
export class MenuDetailsComponent implements OnInit {
  details: any;

  constructor(
    private apiMenuService: ApiMenuService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.apiMenuService.getItemsParams(this.route.snapshot?.paramMap?.get('id')?.toString() || '')
      .subscribe((data) => {
        this.details = data;
      });
  }

}
