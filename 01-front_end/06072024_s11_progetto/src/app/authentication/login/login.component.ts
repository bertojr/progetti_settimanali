import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { iAuthData } from '../../models/auth-data';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  authData: iAuthData = {
    email: '',
    password: '',
  };
  constructor(private authSvc: AuthenticationService, private router: Router) {}

  login(): void {
    this.authSvc.login(this.authData).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
