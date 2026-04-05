import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-queue',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './queue.html',
  styleUrls: ['./queue.css']
})
export class QueueComponent {

  users: any[] = [];

  constructor(private http: HttpClient) {}

ngOnInit() {
  this.http.get<any[]>('http://localhost:5062/api/users')
    .subscribe(data => {
      console.log(data);   // 👈 check this
      this.users = data;
    });
}
}