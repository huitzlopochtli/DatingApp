import { AuthService } from './../../_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { Country } from './../../_models/country';
import { LocationService } from './../../_services/location.service';
import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';
import { TouchSequence } from 'selenium-webdriver';
import { log } from 'util';
import { City } from 'src/app/_models/city';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  user: User;
  countries: Country[];
  cities: City[];
  photoUrl: string;
  @ViewChild('editForm') editForm: NgForm;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private route: ActivatedRoute,
    private locationService: LocationService,
    private alertify: AlertifyService,
    private userService: UserService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => (this.user = data['user']));

    this.locationService.getCoutries().subscribe(countries => {
      this.countries = countries;
      for (let i = 0; i < this.countries.length; i++) {
        if (this.countries[i].id === this.user.city.country.id) {
          this.cities = this.countries[i].cities;
        }
      }
    });

    this.authService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);
  }

  changeCities() {
    for (let i = 0; i < this.countries.length; i++) {
      if (+this.countries[i].id === +this.user.city.country.id) {
        this.user.cityId = this.countries[i].cities[0].id;
        this.cities =
          this.countries[i].cities.length > 0 ? this.countries[i].cities : null;
      }
    }
  }

  updateUser() {
    this.userService
      .updateUser(this.authService.decodedToken.nameid, this.user)
      .subscribe(next => {
        this.alertify.success('Profile updated successfully');
        this.editForm.reset({
          introduction: this.user.introduction,
          lookingFor: this.user.lookingFor,
          interestes: this.user.interestes,
          'user.cityId': +this.user.cityId,
          'user.city.country.id': +this.user.city.country.id
        });
      }, error => {
        this.alertify.error(error);
      });
  }

  updateMainPhoto(photoUrl) {
    this.user.photoUrl = photoUrl;
  }
}
