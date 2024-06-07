import { Component } from '@angular/core';
import { AuthenticationService } from '../../authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  isLoggedIn: boolean = false;
  constructor(private authSvc: AuthenticationService, private router: Router) {}

  ngOnInit() {
    this.authSvc.isLoggedIn.subscribe(
      (isLoggedIn) => (this.isLoggedIn = isLoggedIn)
    );
  }
  logout() {
    this.authSvc.logout();
    this.router.navigate(['/auth']);
  }
}
