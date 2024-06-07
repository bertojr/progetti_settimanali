import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iMovie } from '../models/movie';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  urlApi: string = 'http://localhost:3000/movies';
  constructor(private http: HttpClient) {}

  getMovies(): Observable<iMovie[]> {
    return this.http.get<iMovie[]>(this.urlApi);
  }

  getMoviesById(id: number) {
    return this.http.get(`${this.urlApi}/${id}`);
  }
}
