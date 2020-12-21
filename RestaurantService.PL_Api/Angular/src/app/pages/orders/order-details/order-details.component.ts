import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {ApiOrdersService} from '../../../core/_services/api.orders.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss'],
  providers: [ApiOrdersService]
})
export class OrderDetailsComponent implements OnInit {
  data: any;

  constructor(
    private route: ActivatedRoute,
    private apiOrdersService: ApiOrdersService
  ) {
  }

  ngOnInit(): void {
    this.apiOrdersService.getItemsParams(this.route.snapshot?.paramMap?.get('id')?.toString() || '')
      .subscribe((data) => {
        this.data = data;
        console.log(data);
      });
  }

}
