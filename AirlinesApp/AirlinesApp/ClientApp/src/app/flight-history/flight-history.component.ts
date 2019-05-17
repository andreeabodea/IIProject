import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../services/history.service';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-flight-history',
  templateUrl: './flight-history.component.html',
  styleUrls: ['./flight-history.component.css']
})
export class FlightHistoryComponent implements OnInit {
  public filterForm: FormGroup;
  airportsList = [];
  airlinesList = [];


  constructor(private historyService: HistoryService,
              private fb: FormBuilder) {
    let controlSet = {
      airports: ['', [Validators.required]],
      airlines: ['', [Validators.required]]
    };
    this.filterForm = this.fb.group(controlSet);
  }

  ngOnInit() {
    this.historyService.getAirlines().subscribe((airlinesParam: any) => {
      this.airlinesList = airlinesParam;
    });
    this.historyService.getAirports().subscribe((airportsParam: any) => {
      this.airportsList = airportsParam;
    });
  }

  search() {
    //id pt filtrare
    this.filterForm.controls.airlines.value;
    this.filterForm.controls.airports.value;
  }
 

}
