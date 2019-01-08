import { environment } from './../../environments/environment';
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

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map(res => {
          const user: any = res;
          if (user) {
            localStorage.setItem('token' , user.token);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            console.log('decoded token: ', this.decodedToken);
          }
        })
      );

    // Same can be done by this but
    // https://stackoverflow.com/questions/51269372/difference-beetwen-pipe-and-subscribe
    // So that we can subscribe to this observable later
    // return this.http.post(this.baseUrl + 'login', model)
    //   .subscribe(res => {
    //     console.log('====================================');
    //     console.log(res);
    //     console.log('====================================');
    //   }, error => {
    //     console.log('====================================');
    //     console.log(error);
    //     console.log('====================================');
    //   });
  }

  register(registerModel: any) {
    return this.http.post(this.baseUrl + 'register', registerModel);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    if (token) {
      this.decodedToken = this.jwtHelper.decodeToken(token);
    }
    return !this.jwtHelper.isTokenExpired(token) && token;
  }
}


