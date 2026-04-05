
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface QueueItem {
  id: number;
  name: string;
  tokenNumber: number;
  status: string;
  createdAt: string;
}

@Injectable({
  providedIn: 'root'
})
export class QueueService {
  private baseUrl = 'http://localhost:5062/api/Queue';

  constructor(private http: HttpClient) {}

  add(name: string): Observable<QueueItem> {
    return this.http.post<QueueItem>(`${this.baseUrl}/add?Name=${name}`, {});
  }

  getQueue(): Observable<QueueItem[]> {
    return this.http.get<QueueItem[]>(this.baseUrl);
  }

  next(): Observable<QueueItem> {
    return this.http.post<QueueItem>(`${this.baseUrl}/next`, {});
  }

  complete(id: number): Observable<QueueItem> {
    return this.http.post<QueueItem>(`${this.baseUrl}/complete/${id}`, {});
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
