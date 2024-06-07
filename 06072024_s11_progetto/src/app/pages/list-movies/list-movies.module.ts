import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListMoviesRoutingModule } from './list-movies-routing.module';
import { ListMoviesComponent } from './list-movies.component';
import { ComponentsModule } from '../../components/components.module';

@NgModule({
  declarations: [ListMoviesComponent],
  imports: [CommonModule, ListMoviesRoutingModule, ComponentsModule],
})
export class ListMoviesModule {}
