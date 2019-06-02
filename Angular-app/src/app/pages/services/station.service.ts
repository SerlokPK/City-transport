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
  private stationsList: Station[] = [];

  constructor() { }
}
