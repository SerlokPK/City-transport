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
    const url = `${baseUrl}values/schedules/${lineNumber}/${dayType}`;
    const parameters = {
      LineNumber: lineNumber,
      DayType: dayType
    };
    return this.http.get<Schedule>(url, { params: parameters });
  }

  saveLine(line: any) {
    const url = `${baseUrl}admin/Lines`;
    const header = new HttpHeaders({
      Authorization: 'Bearer ' + sessionStorage.getItem('jwt')
    });
    return this.http.post<any>(url, line, { headers: header });
  }

  updateLine(line: any) {
    const url = `${baseUrl}admin/Lines`;
    const header = new HttpHeaders({
      Authorization: 'Bearer ' + sessionStorage.getItem('jwt')
    });
    return this.http.put<any>(url, line, { headers: header });
  }

  filterDepartures(departures: string) {
    const departureArray = departures.split(' ');
    const regexExp = new RegExp('^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])(:[0-5][0-9])?$');
    return departureArray.filter(x => {
      return regexExp.test(x);
    });
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

  convertToFrontRideType(type: string) {
    if (type === 'URBAN') {
      return 'Gradski';
    } else {
      return 'Prigradski';
    }
  }

  convertLineNames(lineName: string) {
    const newName = this.splitName(lineName);
    if (!newName[1]) {
      return newName[0];
    }
    return `${newName[1]}-${newName[0]}`;
  }

  splitName(name: string) {
    return name.split('-');
  }
}
