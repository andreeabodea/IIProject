import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AirlinesDetailsComponent } from './airlines-details/airlines-details.component';
import { FlightHistoryComponent } from './flight-history/flight-history.component';
import { ManageFlightsComponent } from './manage-flights/manage-flights.component';

const routes: Routes = [
  { path: '', component: AirlinesDetailsComponent },
  { path: 'history', component: FlightHistoryComponent },
  { path: 'flights', component: ManageFlightsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
