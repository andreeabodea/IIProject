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
            Airline al1 = AddAirlineToDbContext("Tarom", "S.C. Transporturile Aeriene Române S.A. este transportatorul de pavilion și cea mai veche companie aeriană din România cu sediul în Otopeni, în apropiere de București. Sediul central și centrul său principal sunt la Aeroportul Internațional Henri Coandă.");
            Airline al2 = AddAirlineToDbContext("Wizz Air", "Wizz Air este o companie aeriană maghiară, deținută de Wizz Air Holdings Plc și axată pe zboruri în Europa.");
            Airline al3 = AddAirlineToDbContext("Volotea", "Volotea este o companie spaniolă de aviație privată cu sediul în Asturia.");
            Airline al4 = AddAirlineToDbContext("Turkish Airlines", "THY - Turkish Airlines, Inc. este compania aeriană națională a Turciei cu baza în Istanbul. Compania operează o rețea de transport de pasageri pe cale aeriană în 219 de orașe internaționale și 42 naționale, deservând un total de 262 de aeroporturi în Europa, Asia, Africa și America.");
            Airline al5 = AddAirlineToDbContext("Blue Air", "Blue Air este o companie română de aviație privată, de tip hybrid, cu sediul în București. Baza principală a companiei este Aeroportul Internațional Henri Coandă, principalul aeroport al Bucureștiului. În anul 2009, compania a transportat 1,7 milioane de pasageri, cu un grad mediu de ocupare a aeronavelor de 75%.");
            Airline al6 = AddAirlineToDbContext("Ryanair", "Ryanair este o companie aeriană irlandeză de tip low-cost, deținută de Ryanair Holdings plc, cea mai mare din Europa, depășind la numărul de pasageri și profit toate companiile aeriane, inclusiv cele ce nu sunt low-cost.");

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

            Airport ai1 = AddAirportToDbContext("Aeroportul International Avram Iancu Cluj", "Cluj");
            Airport ai2 = AddAirportToDbContext("Henri Coandă", "Bucuresti");
            Airport ai3 = AddAirportToDbContext("Fiumicino", "Roma");
            Airport ai4 = AddAirportToDbContext("Aeroportul Tenerife Nord", "Tenerife");
            Airport ai5 = AddAirportToDbContext("Charles de Gaulle", "Paris");
            Airport ai6 = AddAirportToDbContext("Dubai International Airport", "Dubai");
            Airport ai7 = AddAirportToDbContext("Los Angeles International Airport", "Los Angeles");

            Flight f1 = AddFlightToDbContext("F5346", ap1, ai3, ai1, 50);
            Flight f2 = AddFlightToDbContext("F6788", ap2, ai7, ai2, 33);
            Flight f3 = AddFlightToDbContext("F2235", ap3, ai6, ai4, 120);
            Flight f4 = AddFlightToDbContext("F8542", ap4, ai4, ai2, 45);
            Flight f5 = AddFlightToDbContext("F3435", ap5, ai2, ai1, 57);
            Flight f6 = AddFlightToDbContext("F0283", ap6, ai7, ai4, 80);
            Flight f7 = AddFlightToDbContext("F5234", ap7, ai3, ai5, 24);
            Flight f8 = AddFlightToDbContext("F1234", ap8, ai7, ai5, 78);
            Flight f9 = AddFlightToDbContext("F4682", ap9, ai4, ai2, 134);
            Flight f10 = AddFlightToDbContext("F1344", ap10, ai1, ai6, 47);
            Flight f11 = AddFlightToDbContext("F9732", ap11, ai7, ai6, 76);
            Flight f12 = AddFlightToDbContext("F4663", ap12, ai3, ai1, 89);
            Flight f13 = AddFlightToDbContext("F9765", ap13, ai4, ai5, 110);
            Flight f14 = AddFlightToDbContext("F2235", ap14, ai1, ai7, 120);
            Flight f15 = AddFlightToDbContext("F7532", ap15, ai4, ai7, 90);

            appDbContext.SaveChanges();
        }


        private Airline AddAirlineToDbContext(string name, string description)
        {
            return appDbContext.Airlines.Add(new Airline { Name = name , Description=description}).Entity;
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

        private User AddUserToDbContext(string username, string password)
        {
            return appDbContext.Users.Add(new User { UserName = username,  Password= password }).Entity;
        }

    }
}
