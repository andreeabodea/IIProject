import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable()
export class AirlinesService extends BaseService {

  baseUrl: string = '';

  constructor(private httpClient: HttpClient) {
    super();
  }

  getAirlines() {
    return this.httpClient.get(this.baseUrl + "/airlines", { headers: this.headers }).pipe(catchError(this.handleError));
  }

}
