import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  loginModel: any = {};
  photoUrl: string;


  constructor( public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router ) { }

  ngOnInit() {
    this.authService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);
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
      }, () => {
        this.router.navigate(['/members']);
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
    localStorage.removeItem('currentUser');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
    this.alertify.warning('Logged out');
    this.router.navigate(['']);
  }
}


