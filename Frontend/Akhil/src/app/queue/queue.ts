import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-queue',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './queue.html'
})
export class QueueComponent {

  queue: any[] = [];
  userId = 1; // TEMP (later from login)

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadQueue();
  }

  joinQueue() {
    this.http.post(`https://localhost:5001/api/queue/join?userId=${this.userId}`, {})
      .subscribe(() => {
        alert('Joined Queue');
        this.loadQueue();
      });
  }

  loadQueue() {
    this.http.get<any[]>('https://localhost:5001/api/queue')
      .subscribe(res => this.queue = res);
  }
}