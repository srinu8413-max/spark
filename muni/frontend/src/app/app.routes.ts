import { Routes } from '@angular/router';
import { ManageQueue } from './manage-queue/manage-queue';
import { ViewQueue } from './view-queue/view-queue';

export const routes: Routes = [
  { path: 'manage', component: ManageQueue },
  { path: 'view', component: ViewQueue },
  { path: '', redirectTo: 'manage', pathMatch: 'full' }
];