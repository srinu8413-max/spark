import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { QueueService } from '../services/queue.service';

@Component({
  selector: 'app-queue',
  standalone: true,
  imports: [CommonModule, FormsModule],
templateUrl: './checkqueue.html' 
})
export class QueueComponent implements OnInit {

  queueList: any[] = [];

  newQueue = {
    tokenNumber: 0,
    customerName: ''
  };

  constructor(private service: QueueService) {}

  ngOnInit(): void {
    this.loadQueue();
  }

  loadQueue(): void {
    this.service.getQueue().subscribe((res: any) => {
      this.queueList = res;
    });
  }

  addQueue(): void {
    this.service.addQueue(this.newQueue).subscribe(() => {
      this.newQueue = { tokenNumber: 0, customerName: '' };
      this.loadQueue();
    });
  }

  updateStage(id: number, stage: string): void {
    this.service.updateStage(id, stage).subscribe(() => {
      this.loadQueue();
    });
  }
}