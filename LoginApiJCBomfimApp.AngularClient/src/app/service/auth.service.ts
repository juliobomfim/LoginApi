import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { UserClaim } from '../model/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public signIn(username: string, password: string){
    return this.http.post<Response>('api/v1/Auth/signin', {
      username: username,
      password: password
    });
  }

  public signOut(){
    return this.http.get('api/v1/Auth/signout');
  }

  public getUser(){
    return this.http.get<UserClaim[]>('api/v1/user');
  }

  public isSignedIn(): Observable<boolean> {
    return this.getUser().pipe(
      map((userClaims) => {
        const hasClaims = userClaims.length > 0;
        return !hasClaims ? false : true;
      }),
      catchError((error) => {
        return of(false);
      }));
  }
}
