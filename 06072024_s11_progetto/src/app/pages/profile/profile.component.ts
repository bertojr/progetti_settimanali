import { FavouriteMovieService } from './../../services/favourite-movie.service';
import { Component } from '@angular/core';
import { AuthenticationService } from '../../authentication/authentication.service';
import { iFavouriteMovie } from '../../models/favourite-movie';
import { iUser } from '../../models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent {
  favouriteMovies: iFavouriteMovie[] = [];
  user!: iUser;
  constructor(
    private authSvc: AuthenticationService,
    private favouriteMovieSvc: FavouriteMovieService
  ) {}

  ngOnInit() {
    this.authSvc.user$.subscribe((user) => {
      if (user) {
        this.user = user;
        this.favouriteMovieSvc
          .getFavouriteMoviesByUserId(this.user.id)
          .subscribe((movies) => {
            this.favouriteMovies = movies;
          });
      }
    });
  }
  removeFromFavourite(id: number): void {
    this.favouriteMovieSvc.delete(id).subscribe(() => {
      this.favouriteMovies = this.favouriteMovies.filter(
        (movie) => movie.id != id
      );
    });
  }
}
