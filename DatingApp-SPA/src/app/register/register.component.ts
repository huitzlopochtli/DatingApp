import { LocationService } from './../_services/location.service';
import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import { Country } from '../_models/country';
import { City } from '../_models/city';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  registerModel: any = {};
  registerForm: FormGroup;

  countries: Country[];
  cities: City[];

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private locationService: LocationService
  ) {}

  ngOnInit() {
    this.createRegisterForm();
    this.locationService.getCoutries().subscribe(countries => {
      this.countries = countries;
      this.cities = this.countries[0].cities;
    console.log(this.countries, this.cities);
    });
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value
      ? null
      : { mismatch: true };
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        genderId: ['2'],
        username: ['', Validators.required],
        knownAs: ['', Validators.required],
        dateOfBirth: [null, Validators.required],
        cityId: ['0', Validators.required],
        country: ['0', Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(8)
          ]
        ],
        confirmPassword: ['', Validators.required]
      },
      { validator: this.passwordMatchValidator }
    );
  }

  register() {
    // this.authService.register(this.registerModel).subscribe(res => {
    //   console.log('REGISTERED!', res, this.registerModel);
    //   this.alertify.success('Registered successful');
    // }
    // , error => {
    //   console.log('REGISTRATION ERROR!', error);
    //   this.alertify.error(error);
    // }
    // );
    console.log(this.registerForm.value);
  }

  cancel() {
    this.cancelRegister.emit();
    console.log('CANCELLED!');
  }
}
