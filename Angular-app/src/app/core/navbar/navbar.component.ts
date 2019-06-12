import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/pages/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn: boolean;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.isLoggedIn = sessionStorage.getItem('role') ? true : false;
  }

  onLogout() {
    this.userService.logOut();
    // this.router.navigate(['/rides']);
    location.reload();
  }
}
