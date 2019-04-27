import { Component, OnInit } from '@angular/core';
import { MatSidenavModule } from '@angular/material';

@Component({
  selector: 'app-app-navigation',
  templateUrl: './app-navigation.component.html',
  styleUrls: ['./app-navigation.component.css']
})
export class AppNavigationComponent implements OnInit {
  title = 'AirlinesApp';
  constructor() { }

  ngOnInit() {
  }

}
