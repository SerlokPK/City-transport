import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Price } from '../classes/price';

const baseUrl = 'http://localhost:52295/api/';

@Injectable({
  providedIn: 'root'
})
export class PriceService {

  constructor(private http: HttpClient) { }

  getPrices(types: any): Observable<Price> {
    const url = `${baseUrl}values/price/${types.passengerType}/${types.ticketType}`;
    const parameters = {
      PassengerType: types.passengerType,
      TicketType: types.ticketType
    };
    return this.http.get<Price>(url, { params: parameters });
  }

  returnValidCardType(type: string) {
    if (type === 'Vremenska') {
      return 'Time';
    } else if (type === 'Dnevna') {
      return 'Daily';
    } else if (type === 'Mesecna') {
      return 'Monthly';
    } else {
      return 'Yearly';
    }
  }

  returnValidPassengerType(type: string) {
    if (type === 'Djacka') {
      return 'Student';
    } else if (type === 'Penzionerksa') {
      return 'Pensioner';
    } else {
      return 'Regular';
    }
  }
}
