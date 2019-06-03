export class Vehicle {
    Id: number;
    X: number;
    Y: number;

    constructor(vehicle: Vehicle) {
        this.Id = vehicle.Id;
        this.X = vehicle.X;
        this.Y = vehicle.Y;
    }
}
