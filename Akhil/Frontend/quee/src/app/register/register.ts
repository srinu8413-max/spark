import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class RegisterComponent {

  user = {
    name: '',
    email: '',
    password: '',
    role: ''
  };
constructor(private http: HttpClient, private router: Router) {}

register() {
  this.http.post('http://localhost:5062/api/users', this.user)
    .subscribe({
      next: (res) => {
        alert('Registered successfully');
        this.router.navigate(['/queue']);
        console.log(res);
      },
      error: (err) => {
        console.error("ERROR:", err);
        alert('Error occurred');
      }
    });
}
}
