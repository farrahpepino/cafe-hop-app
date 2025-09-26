import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginDto } from '../Models/LoginDto';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class Auth {
  constructor(private http: HttpClient){}
  apiUrl = "http://localhost:5294/auth";

  getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem("token");
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  }
  
  registerUser(user: User): Observable<string>{
    return this.http.post<string>(`${this.apiUrl}/register`, user, { responseType: 'text' as 'json' });
  }

  loginUser(user: LoginDto): Observable<string>{
    return this.http.post<string>(`${this.apiUrl}/login`, user, { responseType: 'text'as 'json'});
  }

}
