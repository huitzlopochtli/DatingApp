import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  loginModel: any = {};


  constructor(private authService: AuthService) { }

  ngOnInit() {
  }


  login() {
    this.authService.login(this.loginModel)
      .subscribe(next => {
        console.log('====================================');
        console.log('LOGGED IN!');
        console.log('====================================');
      }, error => {
        alert('Username or password incorrect');
        console.log('====================================');
        console.log('ERROR', error);
        console.log('====================================');
      });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logOut() {
    localStorage.removeItem('token');
    console.log('====================================');
    console.log('LOGGED OUT!');
    console.log('====================================');
  }
}


