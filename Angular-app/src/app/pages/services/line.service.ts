import { Injectable } from '@angular/core';
import { Line } from '../classes/line';
import { LineSearchResult } from '../classes/line-search-result';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

const baseUrl = 'http://localhost:52295/api/';

@Injectable({
  providedIn: 'root'
})
export class LineService {
  private lineList: Line[] = [];

  constructor(private http: HttpClient) { }

  getAllLines(LineType): Observable<LineSearchResult> {
    const url = `${baseUrl}/values/lines?LineType= ${LineType}`;
    return this.http.get(url)
      .map(data => new LineSearchResult(data));
  }

  getLine(id: number): Line {
    return this.lineList.find(x => x.id === id);
  }
}
