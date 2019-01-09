import { Entity } from './entity';
import { City } from './city';

export interface Country extends Entity {
    countryName: string;
    cities: City[];
}
