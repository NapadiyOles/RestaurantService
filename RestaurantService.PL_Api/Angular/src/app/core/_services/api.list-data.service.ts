import {Observable} from 'rxjs';
import {ApiDataService} from './api.data.service';

export abstract class ApiListDataService<L extends any, T extends any> extends ApiDataService<T> {

  getItems = (): Observable<L[]> => {
    return this.get<L[]>('');
  }

  getItemsParams = (params: string): Observable<L[]> => {
    return this.get<L[]>(params);
  }

}
