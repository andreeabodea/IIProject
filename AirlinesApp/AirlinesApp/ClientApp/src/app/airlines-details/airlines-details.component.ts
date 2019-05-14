import { Component, OnInit } from '@angular/core';
import { AirlinesService } from '../services/airlines.service';

@Component({
  selector: 'app-airlines-details',
  templateUrl: './airlines-details.component.html',
  styleUrls: ['./airlines-details.component.css']
})
export class AirlinesDetailsComponent implements OnInit {

  private airlines;

  constructor(private airlinesService: AirlinesService) { }

  ngOnInit() {
  }


  getAirlines() {
    this.airlinesService.getAirlines().subscribe((airlinesParam: any) => {
      this.airlines = airlinesParam;
    });
  }
}
