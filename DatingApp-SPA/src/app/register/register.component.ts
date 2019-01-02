import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();

  registerModel: any = {};

  constructor() { }

  ngOnInit() {
  }

  register() {
    console.log('====================================');
    console.log('REGISTERED!', this.registerModel);
    console.log('====================================');
  }

  cancel() {
    console.log('====================================');
    this.cancelRegister.emit();
    console.log('CANCELLED!');
    console.log('====================================');
  }

}
