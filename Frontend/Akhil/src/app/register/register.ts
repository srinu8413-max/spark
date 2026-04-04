import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.html'
})
export class RegisterComponent {

  user = {
    name: '',
    email: '',
    password: '',
    role: 'User'
  };

  constructor(private http: HttpClient) {}

register() {
  this.http.post('https://localhost:7266/api/Auth/register', this.user)
    .subscribe({
      next: () => {
        alert('Registered Successfully');
      },
      error: (err) => {
        console.error(err);
        alert('Error while registering');
      }
    });
}
}