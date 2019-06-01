import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Flight } from '../manage-flights/flight.class';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-manage-flights',
  templateUrl: './manage-flights.component.html',
  styleUrls: ['./manage-flights.component.css']
})
export class ManageFlightsComponent implements OnInit {
  public dialogForm: FormGroup;
  airplanesList = [];
  airportsList = [];


  constructor(private flightService: FlightService,
    private fb: FormBuilder,
    private dialogService: DialogService) {

    let controlSet = {
      toairports: ['', [Validators.required]],
      fromairports: ['', [Validators.required]],
      airplanes: ['', [Validators.required]],
      flightName: ['', [Validators.required]],
      flightDuration: ['', [Validators.required, Validators.pattern("[+]?(([1-9][0-9]*)|(0))([.][0-9]+)?")]]
    };
    this.dialogForm = this.fb.group(controlSet);

  }

  ngOnInit() {
    this.flightService.GetAirplanes().subscribe((airplanesParam: any) => {
      this.airplanesList = airplanesParam;
    },
      e => {
        this.dialogService.showErrorMessageBox(e);
      });
    this.flightService.getAirports().subscribe((airportsParam: any) => {
      this.airportsList = airportsParam;
    },
      e => {
        this.dialogService.showErrorMessageBox(e);
      });
  }

  saveFlight() {

    let flight = new Flight(
      this.dialogForm.controls.toairports.value,
      this.dialogForm.controls.fromairports.value,
      this.dialogForm.controls.airplanes.value,
      this.dialogForm.controls.flightDuration.value,
      this.dialogForm.controls.flightName.value
    );
 
    this.flightService.saveFlight(flight).subscribe(
      result => {
        this.dialogService.showMessageBox("Succes", "The data was succesfully saved.");
      },
      errors => {
        this.dialogService.showErrorMessageBox("An error occured while saving the data. Please verify the data you entered.");
      }
    );

  }

}
