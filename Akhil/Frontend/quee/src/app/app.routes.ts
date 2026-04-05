import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register';
import { QueueComponent } from './queue/queue';

export const routes: Routes = [
  { path: '', component: RegisterComponent },
  { path: 'queue', component: QueueComponent }
];