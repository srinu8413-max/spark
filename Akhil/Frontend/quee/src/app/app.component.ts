import { Component } from '@angular/core';
import { ViewQueue } from './view-queue/view-queue';
import { ManageQueue } from './manage-queue/manage-queue';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ViewQueue, ManageQueue],
  template: `
    <div class="container mt-4">
      <h1 class="mb-3">Queue Management System</h1>
      <app-view-queue></app-view-queue>
      <hr>
      <app-manage-queue></app-manage-queue>
    </div>
  `
})
export class AppComponent {}