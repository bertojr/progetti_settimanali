import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { iFavouriteMovie } from '../models/favourite-movie';
import { Observable } from 'rxjs';
import { iMovie } from '../models/movie';

@Injectable({
  providedIn: 'root',
})
export class FavouriteMovieService {
  urlApi: string = 'http://localhost:3000/favorite-movies';
  constructor(private http: HttpClient) {}

  create(favouriteMovie: iMovie): Observable<iFavouriteMovie> {
    return this.http.post<iFavouriteMovie>(this.urlApi, favouriteMovie);
  }
  delete(id: number): Observable<iFavouriteMovie> {
    return this.http.delete<iFavouriteMovie>(`${this.urlApi}/${id}`);
  }

  getFavouriteMoviesByUserId() {}
}