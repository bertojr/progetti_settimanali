import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from './authentication/authentication.guard';
import { GuestGuard } from './authentication/guest.guard';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
    canActivate: [GuestGuard],
    canActivateChild: [GuestGuard],
  },
  {
    path: '',
    loadChildren: () =>
      import('./pages/list-movies/list-movies.module').then(
        (m) => m.ListMoviesModule
      ),
    canActivate: [AuthenticationGuard],
    canActivateChild: [AuthenticationGuard],
  },
  {
    path: 'users',
    loadChildren: () =>
      import('./pages/users/users.module').then((m) => m.UsersModule),
    canActivate: [AuthenticationGuard],
    canActivateChild: [AuthenticationGuard],
  },
  {
    path: 'profile',
    loadChildren: () =>
      import('./pages/profile/profile.module').then((m) => m.ProfileModule),
    canActivate: [AuthenticationGuard],
    canActivateChild: [AuthenticationGuard],
  },
  {
    path: 'details-movie',
    loadChildren: () =>
      import('./pages/details-movie/details-movie.module').then(
        (m) => m.DetailsMovieModule
      ),
    canActivate: [AuthenticationGuard],
    canActivateChild: [AuthenticationGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
