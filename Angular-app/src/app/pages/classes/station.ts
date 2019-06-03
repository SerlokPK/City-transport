import { Line } from './line';

export class Station {
    Id: number;
    Name: string;
    Address: string;
    X: number;
    Y: number;
    Lines: Line[] = [];

    constructor(station: Station) {
        this.Id = station.Id;
        this.Address = station.Address;
        this.Name = station.Name;
        this.X = station.X;
        this.Y = station.Y;
        this.Lines = station.Lines;
    }
}
