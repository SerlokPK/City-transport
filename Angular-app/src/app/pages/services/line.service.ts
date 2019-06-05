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

  getAllLinesByRideType(rideType: string): Observable<Line[]> {
    const url = `${baseUrl}values/lines/${rideType}`;
    const parameters = { lineType: rideType };
    return this.http.get<Line[]>(url, { params: parameters });
  }

  getAllLines(): Observable<Line[]> {
    const url = `${baseUrl}values/lines`;
    return this.http.get<Line[]>(url);
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

  returnValidDayType(type: string) {
    if (type === 'Radni dan') {
      return 'WORKDAY';
    } else if (type === 'Subota') {
      return 'SATURDAY';
    } else {
      return 'SUNDAY';
    }
  }

  returnValidRideType(type: string) {
    if (type === 'Gradski') {
      return 'URBAN';
    } else {
      return 'SUBURBAN';
    }
  }
}
