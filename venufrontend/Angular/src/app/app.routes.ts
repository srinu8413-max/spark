import { Routes } from '@angular/router';
import { CheckqueueComponent } from './checkqueue/checkqueue';

export const routes: Routes = [
    { path: '', component: CheckqueueComponent },
    { path: '**', redirectTo: '' }
];
