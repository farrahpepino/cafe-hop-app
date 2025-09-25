import { Component } from '@angular/core';
import { Navbar } from '../navbar/navbar';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [Navbar, CommonModule, FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {

  showForm = false;

  viewForm(){
    if(this.showForm){
      this.showForm=false;
    }
    else{
      this.showForm=true;
    }
  }

  submitForm(){
    alert("what's up!");
    this.showForm = false;
  }
}
