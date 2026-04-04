import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register';
import { QueueComponent } from './queue/queue';

export const routes: Routes = [
  { path: '', redirectTo: 'register', pathMatch: 'full' as const },
  { path: 'register', component: RegisterComponent },
  { path: 'queue', component: QueueComponent }
];