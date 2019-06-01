import { RestCallHeaders } from './services/restCallHeaders.class';
import { Observable, throwError } from 'rxjs';

export abstract class BaseService {
  protected restCallHeaders: RestCallHeaders;
  public static UnauthErrorMessage: string = "Unauthorized access. Maybe the session has expired. Please log in again.";
  public static ForbiddenErrorMessage: string = "Forbidden operation was attempted.";
  public static PayloadTooLargeErrorMessage: string = "Downloaded file is too big.";

  constructor() {
    this.restCallHeaders = new RestCallHeaders();
  }

  get headers() {
    return this.restCallHeaders.getRequestHeadersForLoggedInUser();
  }

  protected handleError(error: any) {
    var applicationError = error.headers.get('Application-Error');

    if (applicationError) {
      return Observable.throw(applicationError);
    }

    var modelStateErrors: string = '';

    if (error.status === 413) {
      modelStateErrors = BaseService.PayloadTooLargeErrorMessage;
    } else if (error.error) {
      for (var key in error.error) {
        if (error.error[key]) {
          modelStateErrors += error.error[key] + '\n';
          console.error(key + ' ' + error.error[key]);
        }
      }
    } else if (error.status === 401) {
      modelStateErrors = BaseService.UnauthErrorMessage;
    } else if (error.status === 403) {
      modelStateErrors = BaseService.ForbiddenErrorMessage;
    }

    modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;

    return throwError(modelStateErrors || 'Error while accessing the server. Please contact your system administrator.');
  }
}
