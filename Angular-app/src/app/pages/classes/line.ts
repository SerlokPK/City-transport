export class Line {
    id: number;
    name: string;
    lineNumber: number;
    lineType: string;
    departureTime: string[];

    constructor(line: Line) {
        this.id = line.id;
        this.name = line.name;
        this.lineNumber = line.lineNumber;
        this.lineType = line.lineType;
        this.departureTime = line.departureTime;
    }
}
