import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable()
export class FlightService extends BaseService {

  baseUrl: string = '';

  constructor(private httpClient: HttpClient) {
    super();
  }

  public getAirports() {
    return this.httpClient.get(this.baseUrl + "/airportsListFlight", { headers: this.headers })
      .pipe(catchError(this.handleError));
  }

  public GetAirplanes() {
    return this.httpClient.get(this.baseUrl + "/airplanesListFlight", { headers: this.headers })
      .pipe(catchError(this.handleError));
  }

  public saveFlight(flight): Observable<boolean> {
    let body = JSON.stringify(flight);

      return this.httpClient.post(this.baseUrl + "/saveFlight", body, { headers: this.headers })
        .pipe(map(res => true),
          catchError(this.handleError));
    }

}

