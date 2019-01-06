import { AuthService } from './../_services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;
  values: any;


  constructor(private http: HttpClient, private authService: AuthService, private r: Router) { }

  ngOnInit() {
    if (this.authService.loggedIn()){
      this.r.navigate(['/members']);
    }
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
    console.log('Registration Mode: ', this.registerMode);
  }

}
