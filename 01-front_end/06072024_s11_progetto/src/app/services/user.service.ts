import { Injectable } from '@angular/core';
import { AuthenticationService } from '../authentication/authentication.service';
import { iUser } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  apiUsers = 'http://localhost:3000/users';
  constructor(private http: HttpClient) {}

  getUsers(): Observable<iUser[]> {
    return this.http.get<iUser[]>(this.apiUsers);
  }
}
