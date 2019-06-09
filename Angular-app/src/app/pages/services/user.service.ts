import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from '../classes/user';

const baseUrl = 'http://localhost:52295/api/';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  registerUser(user: User): Observable<User> {
    const url = `${baseUrl}account/register`;
    const header = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post<User>(url, user, { headers: header });
  }
}
