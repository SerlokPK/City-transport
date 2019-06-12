import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/pages/services/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn: Observable<boolean>;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.isLoggedIn = this.userService.isLoggedIn;
  }

  onLogout() {
    this.userService.logOut();
  }
}
