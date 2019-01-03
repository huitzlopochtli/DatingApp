import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();

  registerModel: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.registerModel).subscribe(res => {
      console.log('====================================');
      console.log('REGISTERED!', res, this.registerModel);
      console.log('====================================');
    }, error => {
      console.log('====================================');
      console.log('REGISTRATION ERROR!', error);
      alert(error.error);
      console.log('====================================');
    });



  }

  cancel() {
    console.log('====================================');
    this.cancelRegister.emit();
    console.log('CANCELLED!');
    console.log('====================================');
  }

}
