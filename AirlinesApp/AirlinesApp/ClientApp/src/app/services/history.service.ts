import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable()
export class HistoryService extends BaseService {

  baseUrl: string = '';

  constructor(private httpClient: HttpClient) {
    super();
  }


  //airport, airline filter
  //flight -> string name,Airplane airplane, Airport fromAirport, Airport toAirport, int duration

  public getAirports() {
    return this.httpClient.get(this.baseUrl + "/airportsList", { headers: this.headers })
      .pipe(catchError(this.handleError));
  }

  public getAirlines() {
    return this.httpClient.get(this.baseUrl + "/airlinesList", { headers: this.headers })
      .pipe(catchError(this.handleError));
  }

}

