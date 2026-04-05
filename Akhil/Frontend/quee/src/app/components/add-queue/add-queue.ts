import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-queue',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <input [(ngModel)]="name" placeholder="Enter name" />
    <button (click)="add()">Add</button>
  `
})
export class AddQueue {

  name: string = '';

  @Output() addUser = new EventEmitter<string>();

  add() {
    if (!this.name.trim()) return;
    this.addUser.emit(this.name);
    this.name = '';
  }
}
