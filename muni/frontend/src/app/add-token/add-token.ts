
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { QueueService ,QueueItem} from '../services/queue';

@Component({
  selector: 'app-add-token',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-token.html'
})
export class AddToken implements OnInit {
  name: string = '';
  queue: QueueItem[] = [];

  constructor(private service: QueueService) {}

  ngOnInit() {
    this.loadQueue();
  }

  // Add new token
  addToken() {
    if (!this.name.trim()) return;
    this.service.add(this.name).subscribe({
      next: () => {
        this.name = '';
        this.loadQueue();
      },
      error: (err) => console.error(err)
    });
  }

  // Load current queue
  loadQueue() {
    this.service.getQueue().subscribe({
      next: (res) => this.queue = res,
      error: (err) => console.error(err)
    });
  }
}
