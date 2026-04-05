import { Routes } from '@angular/router';
import { AddToken } from './add-token/add-token';
import { ViewQueue } from './view-queue/view-queue';

export const routes: Routes = [
  { path: '', component: AddToken },
  { path: 'queue', component: ViewQueue }
];
