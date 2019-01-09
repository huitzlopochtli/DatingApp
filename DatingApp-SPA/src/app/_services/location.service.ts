import { Country } from './../_models/country';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  baseUrl = environment.apiUrl + 'location/';

  constructor(private http: HttpClient) {}

  getCoutries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.baseUrl + 'countries/');
  }
}
