import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Vehicle } from '../classes/vehicle';

const baseUrl = 'http://localhost:52295/api/';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }

  getStationsByLineNumber(lineNumber: string): Observable<Vehicle[]> {
    const url = `${baseUrl}values/Vehicles`;
    const parameters = { LineNumber: lineNumber };
    return this.http.get<Vehicle[]>(url, { params: parameters });
  }
}
