import { iMovie } from './movie';

export interface iFavouriteMovie {
  id: number;
  userId: number;
  movies: iMovie[];
}
