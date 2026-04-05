import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { QueueComponent } from './checkqueue/checkqueue.component';
import { routes } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    QueueComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes)   // ✅ FIX
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}