import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'http://localhost:5000/api/auth/';

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map(res => {
          const user: any = res;
          if (user) {
            localStorage.setItem('token', 'Bearer ' + user.token);
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
}


