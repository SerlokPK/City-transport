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
    const url = `${baseUrl}api/account/logout`;
    const httpOptions = {
      headers: {
        'Content-type': 'application/json',
        Authorization: 'Bearer ' + sessionStorage.getItem('jwt')
      }
    };
    sessionStorage.removeItem('jwt');
    sessionStorage.removeItem('role');
    return this.http.post<any>(url, {}, httpOptions);
  }

  registerUser(user: User): Observable<User> {
    const url = `${baseUrl}api/account/register`;
    // tslint:disable-next-line: max-line-length
    const userData = `Email=${user.Email}&Password=${user.Password}&Address=${user.Address}&FirstName=${user.FirstName}&LastName=${user.LastName}&DayOfBirth=${user.DayOfBirth}&ConfirmPassword=${user.ConfirmPassword}`;
    const httpOptions = {
      headers: {
        'Content-type': 'application/x-www-form-urlencoded',
      }
    };
    return this.http.post<User>(url, userData, httpOptions);
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

        sessionStorage.setItem('jwt', jwt);
        sessionStorage.setItem('role', role);
        this.loggedIn.next(true);
        // callback();
        location.reload();
      },
        error => {
          swal.fire({
            title: 'Greska!',
            text: `Ne postoji nalog`,
            type: 'error',
            confirmButtonText: 'Ok'
          });
        });
  }
}
