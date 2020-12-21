import {Component, OnInit} from '@angular/core';
import {ApiOrdersService} from '../../core/_services/api.orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
  providers: [ApiOrdersService]
})
export class OrdersComponent implements OnInit {
  orders: any;
  search = {
    name: ''
  };

  constructor(
    private apiOrdersService: ApiOrdersService
  ) {
  }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.apiOrdersService.getItems()
      .subscribe((data) => {
        this.orders = data;
      });
  }

  delete(id: number) {
    this.apiOrdersService.deleteItem(id)
      .subscribe((data) => {
        this.getData();
      });
  }
}
