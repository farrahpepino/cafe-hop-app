import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  constructor (private router: Router) {}
  submitForm(){
    this.router.navigate(['/home'])
  }
}
