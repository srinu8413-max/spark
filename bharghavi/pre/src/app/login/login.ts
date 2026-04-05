import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone:true,
  imports:[FormsModule],
  templateUrl: './login.html',
  styleUrl:'./login.css'
})
export class Login {

  username = '';
  password = '';

  constructor(private api: ApiService, private router: Router) {}

  login() {
    this.api.login({
      username: this.username,
      password: this.password
    }).subscribe((res: any) => {

      localStorage.setItem('token', res.token);

      alert('Login Success ✅');

      this.router.navigate(['/dashboard']);

    }, () => {
      alert('Login Failed ❌');
    });
  }
}