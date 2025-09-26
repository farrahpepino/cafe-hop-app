import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ReactiveFormsModule, FormControl, FormGroup , FormsModule, Validators} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Auth } from '../../../Services/auth';
import { UserModel } from '../../../Models/UserModel';
@Component({
  selector: 'app-register',
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  constructor (private router: Router, private authService: Auth) {}

  registerForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(6)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    confirmPassword: new FormControl('', [Validators.required])
  });

  submitForm(){
    if (this.registerForm.invalid) {
      return;
    }

    if (this.registerForm.value.password !== this.registerForm.value.confirmPassword) {
      console.error('Passwords do not match');
      return;
    }

    var user: UserModel = {
      name: this.registerForm.value.name!,
      email: this.registerForm.value.email!,
      password: this.registerForm.value.password!
    }

    this.authService.registerUser(user).subscribe({
      next: (data) => {
        localStorage.setItem('token', data);
        this.router.navigate(['/home']);
      },
      error: (err) => console.error('Registration failed', err.error?.errors || err)
    });
  }
}
