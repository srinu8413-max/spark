import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { QueueService, QueueItem } from '../services/queue.service';

@Component({
  selector: 'app-manage-queue',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './manage-queue.html',
  styleUrls: ['./manage-queue.css']
})
export class ManageQueue {

  queue: QueueItem[] = [];
  name: string = '';

  constructor(private queueService: QueueService) {}

  ngOnInit() {
    this.loadQueue();
  }

  loadQueue() {
    this.queueService.getQueue().subscribe((data: QueueItem[]) => {
      this.queue = data;
    });
  }

  add() {
    if (!this.name) return;

    this.queueService.addToQueue(this.name).subscribe(() => {
      this.name = '';
      this.loadQueue();
    });
  }

  next() {
    this.queueService.callNext().subscribe(() => {
      this.loadQueue();
    });
  }

  complete(id: number) {
    this.queueService.complete(id).subscribe(() => {
      this.loadQueue();
    });
  }

  delete(id: number) {
    this.queueService.delete(id).subscribe(() => {
      this.loadQueue();
    });
  }
}