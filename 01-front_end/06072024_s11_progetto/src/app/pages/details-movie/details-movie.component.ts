import { ActivatedRoute } from '@angular/router';
import { iMovie } from '../../models/movie';
import { MovieService } from './../../services/movie.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-details-movie',
  templateUrl: './details-movie.component.html',
  styleUrl: './details-movie.component.scss',
})
export class DetailsMovieComponent {
  movie!: any;
  constructor(private movieSvc: MovieService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      this.movieSvc.getMoviesById(params.id).subscribe((movie) => {
        this.movie = movie;
      });
    });
  }
}
