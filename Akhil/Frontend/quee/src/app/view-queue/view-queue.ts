import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QueueService, QueueItem } from '../services/queue.service';

@Component({
  selector: 'app-view-queue',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view-queue.html',
  styleUrls: ['./view-queue.css']
})
export class ViewQueue {

  queue: QueueItem[] = [];
  currentToken: QueueItem | null = null;

  constructor(private queueService: QueueService) {}

  ngOnInit() {
    this.loadQueue();
  }

  loadQueue() {
    this.queueService.getQueue().subscribe((data: QueueItem[]) => {
      this.queue = data;

      this.currentToken = this.queue.find(q => q.status === 'InProgress') || null;
    });
  }
}