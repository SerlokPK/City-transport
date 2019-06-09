import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { User } from '../classes/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = this.formBuilder.group({
    Email: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}')]],
    Password: ['', [Validators.required, Validators.maxLength(100), Validators.minLength(6)]],
  });

  constructor(private router: Router, private formBuilder: FormBuilder, private userService: UserService) { }

  ngOnInit() {
  }

  onSubmit() {
    const user = new User(this.loginForm.value);
    this.login(user);
  }

  login(user: User) {
    this.userService.loginUser(user, () => this.router.navigate(['/rides']));
  }
}
