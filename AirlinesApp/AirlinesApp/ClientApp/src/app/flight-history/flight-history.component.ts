import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../services/history.service';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { HistoryServiceSearchParameters } from '../services/history-search-params.class';
import { FlightHistory } from './flight-history.class';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-flight-history',
  templateUrl: './flight-history.component.html',
  styleUrls: ['./flight-history.component.css']
})
export class FlightHistoryComponent implements OnInit {
  public filterForm: FormGroup;
  airportsList = [];
  airlinesList = [];
  flightHistory : FlightHistory;
  public columnsToDisplay = ['name', 'duration', 'airplane', 'fromAirport', 'toAirport'];

  constructor(private historyService: HistoryService,
    private fb: FormBuilder,
    private dialogService: DialogService) {
    let controlSet = {
      airports: ['', [Validators.required]],
      airlines: ['', [Validators.required]]
    };
    this.filterForm = this.fb.group(controlSet);
  }

  ngOnInit() {
    this.historyService.getAirlines().subscribe((airlinesParam: any) => {
      this.airlinesList = airlinesParam;
    },
      e => {
        this.dialogService.showErrorMessageBox(e);
      });
    this.historyService.getAirports().subscribe((airportsParam: any) => {
      this.airportsList = airportsParam;
    },
      e => {
        this.dialogService.showErrorMessageBox(e);
      });
  }

  search() {

    let searchParams = new HistoryServiceSearchParameters(
      this.filterForm.controls.airlines.value,
      this.filterForm.controls.airports.value
    );

    this.historyService.getHistory(searchParams).subscribe((flightHistoryParam: FlightHistory) => {
      this.flightHistory = flightHistoryParam;
    },
      e => {
        this.dialogService.showErrorMessageBox(e);
      });
    
  }



}
