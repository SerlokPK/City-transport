import { Line } from './line';

export class LineSearchResult {
    lineList: Line[];
    count: number;

    constructor(obj?) {
        this.lineList = obj && obj.results.map(elem => new Line(elem)) || [];
        this.count = obj && obj.count || null;
    }
}
