import { Injectable } from '@angular/core';
import { Line } from '../classes/line';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Schedule } from '../classes/schedule';

const baseUrl = 'http://localhost:52295/api/';

@Injectable({
  providedIn: 'root'
})
export class LineService {

  constructor(private http: HttpClient) { }

  getAllLines(rideType: string): Observable<Line[]> {
    const url = `${baseUrl}values/lines`;
    const parameters = { lineType: rideType };
    return this.http.get<Line[]>(url, { params: parameters });
  }

  getLine(id: number, lineList: Line[]): Line {
    return lineList.find(x => x.Id === id);
  }

  getSchedules(lineNumber: string, dayType: string) {
    const url = `${baseUrl}values/schedules`;
    const parameters = {
      LineNumber: lineNumber,
      DayType: dayType
    };
    return this.http.get<Schedule>(url, { params: parameters });
  }
}
