import {Component, OnInit} from '@angular/core';
import {ApiBaseService} from '../../core/_services/api.base.service';
import {ApiMenuService} from '../../core/_services/api.menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  providers: [ApiMenuService]
})
export class MenuComponent implements OnInit {
  menu: any;

  constructor(
    private apiMenuService: ApiMenuService
  ) {
  }

  ngOnInit(): void {
    this.apiMenuService.getItems()
      .subscribe((data) => {
        this.menu = data;
      });
  }

}
