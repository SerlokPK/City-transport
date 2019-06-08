import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { confirmEqual } from '../directives/confirm-equal-validator.directive';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  password: string;
  registerForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    firstname: ['', [Validators.required, Validators.max(255)]],
    lastname: ['', [Validators.required, Validators.max(255)]],
    password: ['', [Validators.required, Validators.max(100)]],
    confirmPassword: ['', [Validators.required, confirmEqual(this.password)]],
    address: ['', [Validators.required, Validators.max(255)]],
    birthday: ['', [Validators.required, Validators.max(255)]]
  });

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
  }

  onSubmit() {
    alert('radi bato');
  }
}
