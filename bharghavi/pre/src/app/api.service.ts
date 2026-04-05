import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:5186/api';

  constructor(private http: HttpClient) {}

  private getHeaders() {
    const token = localStorage.getItem('token');
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${token}`
      })
    };
  }

  // 🔐 LOGIN
  login(data: any) {
    return this.http.post(`${this.baseUrl}/auth/login`, data);
  }

  // ➕ JOIN QUEUE
  joinQueue() {
    return this.http.post(`${this.baseUrl}/queue/join`, {}, this.getHeaders());
  }
}