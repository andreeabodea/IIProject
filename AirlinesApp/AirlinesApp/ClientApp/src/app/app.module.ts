import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';


import { MatSidenavModule, MatToolbarModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppNavigationComponent } from './app-navigation/app-navigation.component';
import { AirlinesDetailsComponent } from './airlines-details/airlines-details.component';
import { FlightHistoryComponent } from './flight-history/flight-history.component';
import { ManageFlightsComponent } from './manage-flights/manage-flights.component';
import { AirlinesService } from './services/airlines.service';

@NgModule({
  declarations: [
    AppComponent,
    AppNavigationComponent,
    AirlinesDetailsComponent,
    FlightHistoryComponent,
    ManageFlightsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSidenavModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    HttpModule,
    HttpClientModule
  ],
  providers: [AirlinesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
