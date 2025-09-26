import { Injectable } from '@angular/core';
import { User } from '../Models/User';
import { HttpClient } from '@angular/common/http';
import { Auth } from './auth';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserData {
  constructor (private http: HttpClient, private authService: Auth){}
  apiUrl = "http://localhost:5294/user";

  getUser(email: string): Observable<User>{
    return this.http.get<User>(`${this.apiUrl}/get-user`, { headers: this.authService.getAuthHeaders(), params: {email} });
  }
  
  getAllUsers(){
    return this.http.get<User[]>(`${this.apiUrl}`, { headers: this.authService.getAuthHeaders() });
  }
}


