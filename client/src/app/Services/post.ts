import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { PostModel } from '../Models/PostModel';
import { Auth } from './auth';

@Injectable({
  providedIn: 'root'
})

export class Post {
  constructor(private http: HttpClient, private authService: Auth){}
  apiUrl = "http://localhost:5294/post";

  createPost(post: PostModel): Observable<PostModel>{
    return this.http.post<PostModel>(`${this.apiUrl}`, post, { headers: this.authService.getAuthHeaders() });
  }

  getAllPosts(): Observable<PostModel[]>{
    return this.http.get<PostModel[]>(`${this.apiUrl}`, { headers: this.authService.getAuthHeaders() });
  } 

  deletePost(id: string): Observable<any>{
    return this.http.delete<any>(`${this.apiUrl}`, { headers: this.authService.getAuthHeaders(), params: {id} });
  }
}