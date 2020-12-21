import {HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import {Observable, throwError as observableThrowError} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {environment} from '../../../environments/environment';
import {Injectable} from '@angular/core';

type BaseHttpParams = HttpParams | {
  [param: string]: string | string[];
};

type BaseHttpHeaders = HttpHeaders | {
  [header: string]: string | string[];
};

type BaseBody = any | null;


export class ApiBaseService {

  constructor(
    private http: HttpClient,
    protected controllerUrl: string,
    protected prefixUrl: string = `${environment.url}`
  ) {
  }

  formatErrors = (error: any) => {
    return observableThrowError(error);
  };

  fullUrl = (action: string): string => {
    return (this.prefixUrl || '') + (this.controllerUrl || '') + (action || '');
  };

  get = <T>(action: string, params?: BaseHttpParams, headers?: BaseHttpHeaders): Observable<T> => {
    return this.http.get<T>(this.fullUrl(action), {params, headers})
      .pipe(catchError(this.formatErrors));
  };

  put = <T>(action: string, body: BaseBody, headers?: BaseHttpHeaders): Observable<T> => {
    return this.http.put<T>(this.fullUrl(action), body, {headers})
      .pipe(catchError(this.formatErrors));
  };

  post = <T>(action: string, body: BaseBody, headers?: BaseHttpHeaders): Observable<T> => {
    return this.http.post<T>(this.fullUrl(action), body, {headers})
      .pipe(catchError(this.formatErrors));
  };

  delete = <T>(action: string, headers?: BaseHttpHeaders): Observable<T> => {
    return this.http.delete<T>(this.fullUrl(action), {headers})
      .pipe(catchError(this.formatErrors));
  };

  patch = <T>(action: string, body: BaseBody, headers?: BaseHttpHeaders): Observable<T> => {
    return this.http.patch<T>(this.fullUrl(action), body, {headers})
      .pipe(catchError(this.formatErrors));
  };

}
