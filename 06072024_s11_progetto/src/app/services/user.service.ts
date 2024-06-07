import { Injectable } from '@angular/core';
import { AuthenticationService } from '../authentication/authentication.service';
import { iUser } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  user!: iUser | null;
  constructor(private authSvc: AuthenticationService) {}

  ngOnInit() {}
  getUsers() {}
}
