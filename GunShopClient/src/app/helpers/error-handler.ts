import {throwError} from 'rxjs';
import {HttpErrorResponse} from '@angular/common/http';

export class ErrorHandler {
  public static handleHttpError(error: any) {
    return throwError(new HttpErrorResponse(error));
  }
}
