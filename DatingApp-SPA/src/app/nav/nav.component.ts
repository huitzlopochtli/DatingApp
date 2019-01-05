import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  loginModel: any = {};


  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }


  login() {
    this.authService.login(this.loginModel)
      .subscribe(next => {
        console.log('====================================');
        console.log('LOGGED IN!');
        console.log('====================================');
        this.alertify.success('Logged in successful');
      }
      , error => {
        this.alertify.error(error);
        console.log('====================================');
        console.log('LOGGIN ERROR', error);
        console.log('====================================');
      }
      );
  }

  loggedIn() {
    // const token = localStorage.getItem('token');
    // return !!token;
    return this.authService.loggedIn();
  }

  logOut() {
    localStorage.removeItem('token');
    console.log('====================================');
    console.log('LOGGED OUT!');
    console.log('====================================');
    this.alertify.warning('Logged out');
  }
}


