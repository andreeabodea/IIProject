export class Flight {
  public ToAirport: number;
  public FromAirport: number;
  public Airplane: number;
  public Duration: number;
  public Name: string;
  

  constructor(ToAirport: number, FromAirport: number,
    Airplane: number, Duration: number, Name: string) {
    this.ToAirport = ToAirport;
    this.FromAirport = FromAirport;
    this.Airplane = Airplane;
    this.Duration = Duration;
    this.Name = Name;
  }
}
