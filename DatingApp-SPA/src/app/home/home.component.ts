import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;
  values: any;


  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
    console.log('====================================');
    console.log(this.registerMode);
    console.log('====================================');
  }


  // getValues() {
  //   this.http.get('http://localhost:5000/api/values')
  //     .subscribe(res => {
  //       console.log('====================================');
  //       console.log(res);
  //       console.log('====================================');
  //       this.values = res;
  //     }, error => {
  //       if (error.status === 401) {
  //         alert('Unauthorize');
  //       }
  //       console.log('====================================');
  //       console.log(error);
  //       console.log('====================================');
  //     });
  // }

}
