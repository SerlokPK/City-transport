export class Line {
    Id: number;
    Name: string;
    Number: number;
    LineType: string;
    DepartureTime: string[];

    constructor(line: Line) {
        this.Id = line.Id;
        this.Name = line.Name;
        this.Number = line.Number;
        this.LineType = line.LineType;
        this.DepartureTime = line.DepartureTime;
    }
}
