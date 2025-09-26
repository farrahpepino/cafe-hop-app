import { Component } from '@angular/core';
import { Navbar } from '../navbar/navbar';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormControl, FormGroup , FormsModule} from '@angular/forms';
import { UserModel } from '../../Models/UserModel';
import { Post } from '../../Services/post';
import { PostModel } from '../../Models/PostModel';

@Component({
  selector: 'app-home',
  imports: [Navbar, CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})

export class Home {
  showForm = false;
  loggedInUser: UserModel  = JSON.parse(localStorage.getItem("loggedInUser")!);
  constructor (private postService: Post){}

  postForm = new FormGroup({
    cafeName: new FormControl(''),
    location: new FormControl(''),
    content: new FormControl('')
  });

  viewForm(){
    if(this.showForm){
      this.showForm=false;
    }
    else{
      this.showForm=true;
    }
  }

  submitForm(){
    var post: PostModel = {
      cafeName: this.postForm.value.cafeName!,
      userId: this.loggedInUser.id!,
      location: this.postForm.value.location!,
      content: this.postForm.value.content!
    }

    this.showForm = false;
  }
}


