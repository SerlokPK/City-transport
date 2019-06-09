import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { User } from '../classes/user';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm = this.formBuilder.group({
    Email: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}')]],
    FirstName: ['', [Validators.required, Validators.maxLength(255)]],
    LastName: ['', [Validators.required, Validators.maxLength(255)]],
    // tslint:disable-next-line: max-line-length
    Password: ['', [Validators.required, Validators.maxLength(100), Validators.minLength(6)]],
    ConfirmPassword: ['', [Validators.required, (control => this.confirmPassword(control, this.registerForm, 'Password'))]],
    Address: ['', [Validators.required, Validators.maxLength(255)]],
    DayOfBirth: ['', [Validators.required, Validators.maxLength(255)]]
  });

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    if (this.registerForm.value.Password !== this.registerForm.value.ConfirmPassword) {
      alert(`Password and confirm password doesn't match`);
      return;
    }
    const user = new User(this.registerForm.value);
    this.registerUser(user);
  }

  registerUser(user: User) {
    this.userService.registerUser(user).subscribe(
      data => {
        this.router.navigate(['login', { queryParams: { registered: 'true' } }]);
      },
      err => {
        console.log('Error while retrieving schedules from server. Reason: ', err.statusText);
      }
    );
  }

  confirmPassword(control: FormControl, group: FormGroup, matchPassword: string) {
    if (!group) {
      return;
    }
    if (control.value && group.controls[matchPassword].value !== control.value) {
      return { notEqual: true };
    }
    return null;
  }
}
