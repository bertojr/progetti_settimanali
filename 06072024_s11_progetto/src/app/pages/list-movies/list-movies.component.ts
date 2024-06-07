import { FavouriteMovieService } from './../../services/favourite-movie.service';
import { iFavouriteMovie } from './../../models/favourite-movie';
import { Component } from '@angular/core';
import { AuthenticationService } from '../../authentication/authentication.service';
import { iMovie } from '../../models/movie';
import { MovieService } from '../../services/movie.service';

@Component({
  selector: 'app-list-movies',
  templateUrl: './list-movies.component.html',
  styleUrl: './list-movies.component.scss',
})
export class ListMoviesComponent {
  moviesArr: iMovie[] = [];
  favoriteMoviesArr: iFavouriteMovie[] = [];
  idUserLoggato!: number;
  constructor(
    private movieSvc: MovieService,
    private authSvc: AuthenticationService,
    private favouriteMovieSvc: FavouriteMovieService
  ) {}

  ngOnInit() {
    this.authSvc.user$.subscribe((user) => {
      if (user) {
        this.idUserLoggato = user.id;
        this.favouriteMovieSvc
          .getFavouriteMoviesByUserId(this.idUserLoggato)
          .subscribe((favMovies) => {
            this.favoriteMoviesArr = favMovies;
          });
      }
    });
    this.movieSvc.getMovies().subscribe((movies) => {
      this.moviesArr = movies;
    });
  }

  toggleFavourite(movie: iMovie) {
    const favouriteMovie = this.favoriteMoviesArr.find(
      (fav) => fav.movie.id == movie.id
    );

    if (favouriteMovie) {
      this.favouriteMovieSvc.delete(favouriteMovie.id).subscribe(() => {
        this.favoriteMoviesArr = this.favoriteMoviesArr.filter(
          (fav) => fav.id !== favouriteMovie.id
        );
      });
    } else {
      this.favouriteMovieSvc
        .create(this.idUserLoggato, movie)
        .subscribe((movies) => {
          this.favoriteMoviesArr.push(movies);
        });
    }
  }

  isFavourite(movie: iMovie): boolean {
    return this.favoriteMoviesArr.some((fav) => fav.movie.id == movie.id);
  }
}
