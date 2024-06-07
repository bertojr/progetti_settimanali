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
  constructor(private movieSvc: MovieService) {}

  ngOnInit() {
    this.movieSvc.getMovies().subscribe((movies) => {
      this.moviesArr = movies;
    });
  }
}
