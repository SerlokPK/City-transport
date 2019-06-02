import { DecimalPipe } from '@angular/common';

export class Station {
    id: number;
    name: string;
    address: string;
    longitude: number;
    latitude: number;

    constructor(station: Station) {
        this.id = station.id;
        this.address = station.address;
        this.name = station.name;
        this.longitude = station.longitude;
        this.latitude = station.latitude;
    }
}
