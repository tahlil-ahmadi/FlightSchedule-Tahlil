import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FlightScheduleModule } from './flight-schedule/flight-schedule.module'

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FlightScheduleModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
