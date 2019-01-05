import { AlertifyService } from './../_services/alertify.service';
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

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.registerModel).subscribe(res => {
      console.log('REGISTERED!', res, this.registerModel);
      this.alertify.success('Registered successful');
    }
    , error => {
      console.log('REGISTRATION ERROR!', error);
      this.alertify.error(error);
    }
    );
  }

  cancel() {
    this.cancelRegister.emit();
    console.log('CANCELLED!');
  }

}
