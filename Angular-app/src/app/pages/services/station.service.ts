import { Injectable } from '@angular/core';
import { Station } from '../classes/station';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

const baseUrl = 'http://localhost:52295/api/';

@Injectable({
  providedIn: 'root'
})
export class StationService {
  constructor(private http: HttpClient) { }

  getStationsByLineNumber(lineNumber: string): Observable<Station[]> {
    const url = `${baseUrl}values/Stations/${lineNumber}`;
    const parameters = { LineNumber: lineNumber };
    return this.http.get<Station[]>(url, { params: parameters });
  }

  getAllStations() {
    const url = `${baseUrl}values/Stations`;
    return this.http.get<Station[]>(url);
  }

  getStationById(id: number, stationList: Station[]): Station {
    return stationList.find(x => x.Id === id);
  }

  saveStation(station: any) {
    const url = `${baseUrl}values/Stations`;
    return this.http.post<any>(url, station);
  }

  updateStation(station: any) {
    const url = `${baseUrl}values/Stations`;
    return this.http.put<any>(url, station);
  }
}
