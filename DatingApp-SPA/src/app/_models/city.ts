import { Country } from './country';
import { Entity } from './entity';

export interface City extends Entity {
    cityName: string;
    country: Country;
}
