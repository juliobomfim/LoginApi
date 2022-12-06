import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { UserClaim } from '../model/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public signIn(userName: string, password: string){
    return this.http.post<Response>('https://localhost:7256/api/v1/Auth/signin', {
      userName: userName,
      password: password
    });
  }

  public signOut(){
    return this.http.get('https://localhost:7256/api/v1/Auth/signout');
  }

  public getUser(){
    return this.http.get<UserClaim[]>('https://localhost:7256/api/v1/user');
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
