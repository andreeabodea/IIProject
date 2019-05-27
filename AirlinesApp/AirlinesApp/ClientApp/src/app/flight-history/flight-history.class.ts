export class FlightHistory {

  constructor() {
    this.flights = [];
  }
  flights: Flight[]
}

export class Flight {
  name: string;
  duration: string;
  airplane: string;
  fromAirport: string;
  toAirport: string;
}
