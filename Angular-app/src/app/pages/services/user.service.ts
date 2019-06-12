import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from '../classes/user';
import swal from 'sweetalert2';

const baseUrl = 'http://localhost:52295/';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private loggedIn = new BehaviorSubject<boolean>(false);

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  constructor(private http: HttpClient) { }

  logOut() {
    this.loggedIn.next(false);
    const url = `${baseUrl}account/logout`;
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.http.post<any>(url, {}, { headers: header });
  }

  registerUser(user: User): Observable<User> {
    const url = `${baseUrl}account/register`;
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.http.post<User>(url, user, { headers: header });
  }

  loginUser(user: User, callback: any) {
    const userData = `username=${user.Email}&password=${user.Password}&grant_type=password`;
    const httpOptions = {
      headers: {
        'Content-type': 'application/x-www-form-urlencoded',
      }
    };

    this.http.post<any>(baseUrl + 'oauth/token', userData, httpOptions)
      .subscribe(data => {
        const jwt = data.access_token;

        const jwtData = jwt.split('.')[1];
        const decodedJwtJsonData = window.atob(jwtData);
        const decodedJwtData = JSON.parse(decodedJwtJsonData);
        const role = decodedJwtData.role;

        localStorage.setItem('jwt', jwt);
        localStorage.setItem('role', role);
        this.loggedIn.next(true);
        callback();
      },
        error => {
          swal.fire({
            title: 'Greska!',
            text: `${error.message}`,
            type: 'error',
            confirmButtonText: 'Ok'
          });
        });
  }
}
