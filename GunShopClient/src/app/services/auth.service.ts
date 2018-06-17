import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Credentials} from '../models/credentials';
import {catchError} from 'rxjs/operators';
import {ErrorHandler} from '../helpers/error-handler';
import {settings} from '../settings';
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper : JwtHelperService;

  constructor(private http: HttpClient) {
    this.jwtHelper = new JwtHelperService();
  }

  httpOptions: any = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  get isLoggedIn(): boolean {
    let token = this.getToken();
    return !this.jwtHelper.isTokenExpired(token);
  }

  authorize(user: Credentials): Observable<any> {
    return this.http.post(settings.url.user + 'token', user, this.httpOptions).pipe(
      catchError(ErrorHandler.handleHttpError)
    );
  }

  logOut() {
    localStorage.removeItem('username');
    localStorage.removeItem('token');
  }

  storeToken(token: string) {
    localStorage.removeItem('token');
    let decodedToken = this.jwtHelper.decodeToken(token);
    console.log('Decoded token', decodedToken);
    localStorage.setItem('username', decodedToken.name);
    localStorage.setItem('token', token);
  }

  getToken(): string {
    return localStorage.getItem('token');
  }
}
