import {Observable} from 'rxjs';
import {ApiBaseService} from './api.base.service';

export abstract class ApiDataService<T extends any> extends ApiBaseService {
  getItem = (id: any): Observable<T> => {
    return this.get<T>(String(id || ''));
  };

  createItem = (data: T): Observable<T> => {
    return this.post<T>('', JSON.stringify(data), {'Content-Type': 'application/json'});
  };

  createItemPut = (data: T): Observable<T> => {
    return this.put<T>('', JSON.stringify(data), {'Content-Type': 'application/json'});
  };

  updateItem = (id: number, data: T): Observable<T> => {
    return this.put<T>(String(id || ''), JSON.stringify(data));
  };
  updateItemPost = (data: T): Observable<T> => {
    return this.post<T>('', JSON.stringify(data), {'Content-Type': 'application/json'});
  };

  deleteItem = (id: number): Observable<void> => {
    return this.delete<void>(String(id || ''));
  };

  patchItem = (id: number, data: T): Observable<T> => {
    return this.patch<T>(String(id || ''), JSON.stringify(data));
  };
}
