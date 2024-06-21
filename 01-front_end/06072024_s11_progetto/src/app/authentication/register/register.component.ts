import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { iUser } from '../../models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  newUser: Partial<iUser> = {};
  constructor(private authSvc: AuthenticationService, private router: Router) {}

  register(): void {
    this.authSvc.register(this.newUser).subscribe(() => {
      alert('Registrazioen effettuata con successo');
      this.router.navigate(['/auth']);
    });
  }
}
