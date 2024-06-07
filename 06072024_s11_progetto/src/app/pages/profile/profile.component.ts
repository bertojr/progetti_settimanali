import { FavouriteMovieService } from './../../services/favourite-movie.service';
import { Component } from '@angular/core';
import { AuthenticationService } from '../../authentication/authentication.service';
import { iFavouriteMovie } from '../../models/favourite-movie';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent {
  favouriteMovies: iFavouriteMovie[] = [];
  constructor(
    private authSvc: AuthenticationService,
    private favouriteMovieSvc: FavouriteMovieService
  ) {}

  ngOnInit() {
    this.authSvc.user$.subscribe((user) => {
      this.favouriteMovieSvc
        .getFavouriteMoviesByUserId(user?.id)
        .subscribe((movies) => {
          this.favouriteMovies = movies;
          console.log(this.favouriteMovies);
        });
    });
  }

  removeFromFavourite(id: number): void {
    this.favouriteMovieSvc.delete(id).subscribe();
  }
}
