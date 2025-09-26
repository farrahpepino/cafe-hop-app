import { Component } from '@angular/core';
import { Navbar } from '../navbar/navbar';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormControl, FormGroup , FormsModule} from '@angular/forms';
import { User } from '../../Models/User';

@Component({
  selector: 'app-home',
  imports: [Navbar, CommonModule, FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})

export class Home {
  showForm = false;
  loggedInUser: User  = JSON.parse(localStorage.getItem("loggedInUser")!);

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
