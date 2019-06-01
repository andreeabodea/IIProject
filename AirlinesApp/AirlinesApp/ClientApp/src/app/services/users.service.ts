import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { BaseService } from './base.service';


@Injectable()
export class UsersService extends BaseService {

  baseUrl: string = '';

  constructor(private httpClient: HttpClient) {
    super();
  }

  getAllUsers() {
    return this.httpClient.get(this.baseUrl + "/users", { headers: this.headers })
      .pipe(catchError(this.handleError));
  }

  update(id: string, userId: string, isEnabled: boolean, isAdmin: boolean): Observable<boolean> {
    let body = JSON.stringify({ id, userId, isEnabled, isAdmin });

    return this.httpClient.put(this.baseUrl + "/users/" + id, body, { headers: this.headers })
      .pipe(map(res => true),
        catchError(this.handleError));
  }

  create(userId: string, isEnabled: boolean, isAdmin: boolean): Observable<boolean> {
    let body = JSON.stringify({ userId, isEnabled, isAdmin });

    return this.httpClient.post(this.baseUrl + "/users", body, { headers: this.headers })
      .pipe(map(res => true),
        catchError(this.handleError));
  }

  delete(id: string) {
    return this.httpClient.delete(this.baseUrl + "/users/" + id, { headers: this.headers })
      .pipe(map(res => true),
        catchError(this.handleError));
  }

  getCurrentUser() {
    return this.httpClient.get(this.baseUrl + "/currentUser", { headers: this.headers })
      .pipe(catchError(this.handleError));
  }
}

