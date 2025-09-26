import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup , FormsModule} from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  constructor (private router: Router) {}
  loginForm = new FormGroup({
    email: new FormControl(""),
    password: new FormControl("")
  });
  
  submitForm(){
    this.router.navigate(['/home'])
  }
}
