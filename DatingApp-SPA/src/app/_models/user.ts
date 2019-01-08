import { Gender } from './gender';
import { Entity } from './entity';
import { City } from './city';
import { Photo } from './photo';

export interface User extends Entity {
    username: string;
    gender: Gender;
    knownAs: string;
    age: number;
    lastActivity: Date;
    city: City;
    photoUrl: string;
    introduction?: string;
    interestes?: string;
    lookingFor?: string;
    photos?: Photo[];
}
