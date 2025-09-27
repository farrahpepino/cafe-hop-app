import { Component, OnInit } from '@angular/core';
import { Navbar } from '../navbar/navbar';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormControl, FormGroup , FormsModule} from '@angular/forms';
import { UserModel } from '../../Models/UserModel';
import { Post } from '../../Services/post';
import { PostModel } from '../../Models/PostModel';

// reloads could be designed better, just needed to practice LINQ
@Component({
  selector: 'app-home',
  imports: [Navbar, CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})

export class Home implements OnInit {
  constructor (private postService: Post){}
  posts: PostModel[] | null = null;

  ngOnInit(): void {
      this.postService.getAllPosts().subscribe(
        {next: (data: PostModel[]) => {this.posts=data;}}
      )
  }

  showForm = false;
  loggedInUser: UserModel  = JSON.parse(localStorage.getItem("loggedInUser")!);

  postForm = new FormGroup({
    cafeName: new FormControl(''),
    location: new FormControl(''),
    rate: new FormControl(''),
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
      rate: this.postForm.value.rate!.trim(),
      location: this.postForm.value.location!,
      content: this.postForm.value.content!
    }

    this.postService.createPost(post).subscribe({
      next: ()=> {
        window.location.reload();
        this.showForm = false;
      },
      error: (err) => console.error('Failed to post', err.error?.errors || err)
    })
  }

  deletePost(id: string){
    this.postService.deletePost(id).subscribe({
      next: ()=> {
        window.location.reload();
      },
      error: (err) => console.error('Failed to delete post', err.error?.errors || err)
    });
  }
}


