import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QueueService } from '../services/queue';

@Component({
  selector: 'app-view-queue',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view-queue.html'
})
export class ViewQueue implements OnInit {

  queue: any[] = [];

  constructor(private service: QueueService) { }

  ngOnInit() {
    this.loadQueue();
  }

  loadQueue() {
    this.service.getQueue().subscribe(data => {
      this.queue = data;
    });
  }

  next() {
    this.service.next().subscribe(() => this.loadQueue());
  }

  complete(id: number) {
    this.service.complete(id).subscribe(() => this.loadQueue());
  }

  delete(id: number) {
    this.service.delete(id).subscribe(() => this.loadQueue());
  }
}
