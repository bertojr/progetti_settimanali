import { Component, Input } from '@angular/core';
import { iMovie } from '../../models/movie';
import { FavouriteMovieService } from '../../services/favourite-movie.service';

import { iUser } from '../../models/user';
import { UserService } from '../../services/user.service';
import { AuthenticationService } from '../../authentication/authentication.service';
import { take } from 'rxjs';
import { iFavouriteMovie } from '../../models/favourite-movie';

@Component({
  selector: 'app-single-movie',
  templateUrl: './single-movie.component.html',
  styleUrl: './single-movie.component.scss',
})
export class SingleMovieComponent {
  @Input() movie!: iMovie;
  constructor(
    private favouriteMovieSvc: FavouriteMovieService,
    private authSvc: AuthenticationService
  ) {}

  addToFavourite(movie: iMovie): void {
    this.authSvc.user$.pipe(take(1)).subscribe((user) => {
      this.favouriteMovieSvc.create(user?.id, movie).subscribe();
    });
    // uso l'operatore take per prendere solo il primo elemento
    // siccome questo è un componente che viene caricato molteplice volte con un ciclo for
    // se non usavo l'operatore take mi faceva molteplice chiamate,
    // e di conseguenza creava duplicati che non volevo
  }

  removeFromFavourite(id: number): void {
    this.favouriteMovieSvc.delete(id).subscribe();
  }
}
