import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ApiListDataService} from './api.list-data.service';

@Injectable()
export class ApiOrdersService extends ApiListDataService<any, any> {

  constructor(http: HttpClient) {
    super(http, 'Order/');
  }
}
