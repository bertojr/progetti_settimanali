import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';
import { iAuthResponse } from '../models/auth-response';
import { iUser } from '../models/user';
import { iAuthData } from '../models/auth-data';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  urlRegister = 'http://localhost:3000/register';
  urlLogin = 'http://localhost:3000/login';

  authDataSubject = new BehaviorSubject<iUser | null>(null);
  user$ = this.authDataSubject.asObservable();
  syncIsLoggedIn: boolean = false;
  isLoggedIn = this.user$.pipe(
    map((user) => !!user),
    tap((user) => (this.syncIsLoggedIn = user))
  );
  jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(private http: HttpClient) {
    this.restoreUser();
  }

  register(newUser: Partial<iUser>): Observable<iAuthResponse> {
    return this.http.post<iAuthResponse>(this.urlRegister, newUser);
  }
  login(authData: iAuthData): Observable<iAuthResponse> {
    return this.http.post<iAuthResponse>(this.urlLogin, authData).pipe(
      tap((data) => {
        this.authDataSubject.next(data.user);
        localStorage.setItem('accessData', JSON.stringify(data));
      })
    );
  }

  logout(): void {
    this.authDataSubject.next(null);
    localStorage.removeItem('accessData');
  }

  getAccessData(): iAuthResponse | null {
    const accessDataJson = localStorage.getItem('accessData');

    if (!accessDataJson) return null;

    const accessData = JSON.parse(accessDataJson);
    return accessData;
  }

  restoreUser(): void {
    const accessData = this.getAccessData();

    if (!accessData) return;
    if (this.jwtHelper.isTokenExpired(accessData.accessToken)) return;

    this.authDataSubject.next(accessData.user);
  }
}
