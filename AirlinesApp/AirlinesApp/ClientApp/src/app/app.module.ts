import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';


import { MatSidenavModule, MatToolbarModule, MatButtonModule, MatFormFieldModule, MatInputModule} from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material';
import { MatSelectModule } from '@angular/material/select';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppNavigationComponent } from './app-navigation/app-navigation.component';
import { AirlinesDetailsComponent } from './airlines-details/airlines-details.component';
import { FlightHistoryComponent } from './flight-history/flight-history.component';
import { ManageFlightsComponent } from './manage-flights/manage-flights.component';
import { AirlinesService } from './services/airlines.service';
import { HistoryService } from './services/history.service';
import { FlightService } from './services/flight.service';

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
    HttpClientModule,
    MatCardModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatSelectModule
  ],
  providers: [AirlinesService, HistoryService, FlightService],
  bootstrap: [AppComponent]
})
export class AppModule { }
