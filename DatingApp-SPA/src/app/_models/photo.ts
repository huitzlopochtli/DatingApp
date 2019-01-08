import { Entity } from './entity';

export interface Photo {
    id: number;
    url: string;
    description: string;
    dateAdded: Date;
    isProfilePhoto: boolean;
}
