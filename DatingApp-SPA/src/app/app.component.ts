import { User } from 'src/app/_models/user';
import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private authService: AuthService) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    const currentUser: User = JSON.parse(localStorage.getItem('currentUser'));
    if (token) {
      this.authService.decodedToken = token;
    }
    if (currentUser) {
      this.authService.currentUser = currentUser;
      this.authService.changeMemberPhoto(currentUser.photoUrl);
    }
  }
}
