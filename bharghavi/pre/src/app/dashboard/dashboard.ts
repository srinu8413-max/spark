import { Component } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.html',
  styleUrl:'./dashboard.css'
})
export class Dashboard{

  constructor(private api: ApiService) {}

  joinQueue() {
    this.api.joinQueue().subscribe(() => {
      alert('Joined Queue Successfully 🎉');
    }, () => {
      alert('Error joining queue ❌');
    });
  }
}