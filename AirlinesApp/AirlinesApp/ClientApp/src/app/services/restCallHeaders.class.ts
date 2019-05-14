import { HttpHeaders } from '@angular/common/http';

export class RestCallHeaders {

  public getRequestHeadersForLoggedInUserWithCustomHeaders(customHeaders: any): HttpHeaders {
    return new HttpHeaders(customHeaders);
  }

  public getRequestHeadersForLoggedInUser(): HttpHeaders {
    return this.getRequestHeadersForLoggedInUserWithCustomHeaders({ 'Content-Type': 'application/json' });
  }
}
