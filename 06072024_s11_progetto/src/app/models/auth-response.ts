import { iUser } from './user';

export interface iAuthResponse {
  accessToken: string;
  user: iUser;
}
