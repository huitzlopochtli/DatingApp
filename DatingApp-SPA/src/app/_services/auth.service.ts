import { User } from './../_models/user';
import { environment } from './../../environments/environment';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;
  photoUrl = new BehaviorSubject<string>('../../assets/user.png');
  currentPhotoUrl = this.photoUrl.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map(res => {
          const response: any = res;
          if (response) {
            localStorage.setItem('token' , response.token);
            localStorage.setItem('currentUser' , JSON.stringify(response.loggedInUser));
            this.decodedToken = this.jwtHelper.decodeToken(response.token);
            this.currentUser = response.loggedInUser;
            console.log('decoded token: ', this.decodedToken);
            this.changeMemberPhoto(this.currentUser.photoUrl);
          }
        })
      );
  }

  register(registerModel: User) {
    return this.http.post(this.baseUrl + 'register', registerModel);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    if (token) {
      this.decodedToken = this.jwtHelper.decodeToken(token);
    }
    return !this.jwtHelper.isTokenExpired(token) && token;
  }

  changeMemberPhoto(photoUrl: string){
    this.photoUrl.next(photoUrl);
  }
}


