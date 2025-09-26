import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup , FormsModule, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../../../Services/auth';
import { LoginDto } from '../../../Models/LoginDto';
import { UserData } from '../../../Services/user-data';
//what ive learned. you can only store strings with localstorage hence you need to stringigy the data before saving it then parse it when you retrieve it
@Component({
  selector: 'app-login',
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  constructor (private router: Router, private authService: Auth, private userService: UserData) {}
  isLoggedIn = true;

  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("")
  });
  
  submitForm(){
    if (this.loginForm.invalid) {
      return;
    }

    var user: LoginDto = {
      email: this.loginForm.value.email!,
      password: this.loginForm.value.password!
    }

    this.authService.loginUser(user).subscribe({
      next: (data)=>    {
        localStorage.setItem('token', data);
        this.userService.getUser(user.email.trim().toLowerCase()).subscribe({
          next: (data)=> {localStorage.setItem("loggedInUser", JSON.stringify(data))}
        });
        this.router.navigate(['/home'])
      },
      error: (err) => {
        this.isLoggedIn = false;
        console.error('Login failed', err.error?.errors || err);
      }
    });
  }
}
