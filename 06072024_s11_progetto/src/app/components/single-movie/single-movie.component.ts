import { Component, Input } from '@angular/core';
import { iMovie } from '../../models/movie';
import { FavouriteMovieService } from '../../services/favourite-movie.service';

@Component({
  selector: 'app-single-movie',
  templateUrl: './single-movie.component.html',
  styleUrl: './single-movie.component.scss',
})
export class SingleMovieComponent {
  @Input() movie!: iMovie;
  constructor(private favouriteMovieSvc: FavouriteMovieService) {}

  addToFavourite(): void {
    this.favouriteMovieSvc.create(this.movie).subscribe((movie) => {
      console.log('Aggiusto ai preferiti');
    });
  }
}
