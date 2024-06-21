import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DetailsMovieRoutingModule } from './details-movie-routing.module';
import { DetailsMovieComponent } from './details-movie.component';


@NgModule({
  declarations: [
    DetailsMovieComponent
  ],
  imports: [
    CommonModule,
    DetailsMovieRoutingModule
  ]
})
export class DetailsMovieModule { }
