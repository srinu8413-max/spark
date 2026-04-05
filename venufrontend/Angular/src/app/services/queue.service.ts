import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface QueueItem {
  id?: number;
  tokenNumber: string;
  status: string; 
  createdTime?: string;
}

@Injectable({
  providedIn: 'root'
})
export class QueueService {
  // Update this URL if your backend port is different
  private apiUrl = 'http://localhost:5253/api/queue';

  constructor(private http: HttpClient) {}

  // ✅ Matches GET: Check Queue
  getQueue(): Observable<QueueItem[]> {
    return this.http.get<QueueItem[]>(this.apiUrl);
  }

  // ✅ Matches POST: Add Queue
  addQueue(item: QueueItem): Observable<QueueItem> {
    return this.http.post<QueueItem>(this.apiUrl, item);
  }
}
