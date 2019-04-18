using AirlinesApp.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesApp.Db
{
    public class DBSeeder : IDBSeeder
    {
        private readonly AppDbContext appDbContext;

        public DBSeeder(AppDbContext appDbContextParam)
        {
            appDbContext = appDbContextParam;
        }

        public async Task EnsureInitialData()
        {
            if (appDbContext.Configs.Count() > 0)
            {
                return;
            }
            AddDataToDB();
            appDbContext.Configs.Add(new Config { Seeded = true });
            appDbContext.SaveChanges();
        }

        private void AddDataToDB()
        {
            Airline al1 = AddAirlineToDbContext("Tarom");
            Airline al2 = AddAirlineToDbContext("Wizz Air");
            Airline al3 = AddAirlineToDbContext("Volotea");
            Airline al4 = AddAirlineToDbContext("Turkish Airlines");
            Airline al5 = AddAirlineToDbContext("Blue Air");
            Airline al6 = AddAirlineToDbContext("Ryanair");

            Airplane ap1 = AddAirplaneToDbContext("Boeing 787-9 1/200", al1);
            Airplane ap2 = AddAirplaneToDbContext("Airbus A380", al1);
            Airplane ap3 = AddAirplaneToDbContext("Boeing 737-700 ", al1);
            Airplane ap4 = AddAirplaneToDbContext("Douglas DC-3 1/80", al2);
            Airplane ap5 = AddAirplaneToDbContext("Boeing 737 MAX8", al2);
            Airplane ap6 = AddAirplaneToDbContext("Boeing 747-100 ", al3);
            Airplane ap7 = AddAirplaneToDbContext("Boeing 314 Clipper 1/100 ", al3);
            Airplane ap8 = AddAirplaneToDbContext("Delta L-1011 TriStar 1/500", al3);
            Airplane ap9 = AddAirplaneToDbContext("Boeing 777-200 1/200", al4);
            Airplane ap10 = AddAirplaneToDbContext("Airbus A320", al4);
            Airplane ap11 = AddAirplaneToDbContext("Airbus A380", al4);
            Airplane ap12 = AddAirplaneToDbContext("Airbus A350", al4);
            Airplane ap13 = AddAirplaneToDbContext("Airbus A380", al5);
            Airplane ap14 = AddAirplaneToDbContext("Boeing 737-700 ", al5);
            Airplane ap15 = AddAirplaneToDbContext("Douglas DC-3 1/80", al5);
            Airplane ap16 = AddAirplaneToDbContext("Boeing 747-100 ", al6);
            Airplane ap17 = AddAirplaneToDbContext("Boeing 314 Clipper 1/100 ", al6);
            Airplane ap18 = AddAirplaneToDbContext("Delta L-1011 TriStar 1/500", al6);
            Airplane ap19 = AddAirplaneToDbContext("Boeing 777-200 1/200", al6);
            Airplane ap20 = AddAirplaneToDbContext("Airbus A320", al6);

            appDbContext.SaveChanges();
        }


        private Airline AddAirlineToDbContext(string name)
        {
            return appDbContext.Airlines.Add(new Airline { Name = name }).Entity;
        }

        private Airplane AddAirplaneToDbContext(string name, Airline airline)
        {
            return appDbContext.Airplanes.Add(new Airplane { Name = name , Airline = airline}).Entity;
        }

        private Airport AddAirportToDbContext(string name, string city)
        {
            return appDbContext.Airports.Add(new Airport { Name = name , City = city}).Entity;
        }

        private Flight AddFlightToDbContext(string name,Airplane airplane, Airport fromAirport, Airport toAirport, int duration)
        {
            return appDbContext.Flights.Add(new Flight { Name = name, Airplane = airplane, FromAirport = fromAirport, ToAirport = toAirport, Duration = duration }).Entity;
        }

        private User AddUserToDbContext(string firstName, string lastName)
        {
            return appDbContext.Users.Add(new User { FirstName = firstName, LastName= lastName }).Entity;
        }

    }
}
