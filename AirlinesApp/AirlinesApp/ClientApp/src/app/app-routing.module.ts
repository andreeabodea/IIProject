import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AirlinesDetailsComponent } from './airlines-details/airlines-details.component';

const routes: Routes = [
  { path: '', component: AirlinesDetailsComponent }
  //{ path: 'configuration', component: ConfigurationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
