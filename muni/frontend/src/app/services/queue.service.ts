import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface QueueItem {
  id: number;
  name: string;
  tokenNumber: number;
  status: string;
  createdAt: Date;
}

@Injectable({
  providedIn: 'root'
})
export class QueueService {

  private apiUrl = 'http://localhost:5062/api/Queue';

  constructor(private http: HttpClient) { }

  getQueue(): Observable<QueueItem[]> {
    return this.http.get<QueueItem[]>(this.apiUrl);
  }

  addToQueue(name: string): Observable<QueueItem> {
    return this.http.post<QueueItem>(`${this.apiUrl}/add?name=${name}`, {});
  }

  callNext(): Observable<QueueItem> {
    return this.http.post<QueueItem>(`${this.apiUrl}/next`, {});
  }

  complete(id: number) {
    return this.http.post(`${this.apiUrl}/complete/${id}`, {});
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}