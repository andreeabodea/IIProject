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
            Airplane ap3 = AddAirplaneToDbContext("Boeing 737-700 ", al2);
            Airplane ap4 = AddAirplaneToDbContext("Douglas DC-3 1/80", al2);
            Airplane ap5 = AddAirplaneToDbContext("Boeing 737 MAX8", al3);
            Airplane ap6 = AddAirplaneToDbContext("Boeing 747-100 ", al3);
            Airplane ap7 = AddAirplaneToDbContext("Boeing 314 Clipper 1/100 ", al4);
            Airplane ap8 = AddAirplaneToDbContext("Delta L-1011 TriStar 1/500", al4);
            Airplane ap9 = AddAirplaneToDbContext("Boeing 777-200 1/200", al5);
            Airplane ap10 = AddAirplaneToDbContext("Airbus A320", al5);
            Airplane ap11 = AddAirplaneToDbContext("Airbus A380", al6);
            Airplane ap12 = AddAirplaneToDbContext("Airbus A350", al6);
            

            Airport ai1 = AddAirportToDbContext("Aeroportul International Avram Iancu Cluj", "Cluj");
            Airport ai2 = AddAirportToDbContext("Henri Coandă", "Bucuresti");
            Airport ai3 = AddAirportToDbContext("Fiumicino", "Roma");
            Airport ai4 = AddAirportToDbContext("Aeroportul Tenerife Nord", "Tenerife");
            Airport ai5 = AddAirportToDbContext("Charles de Gaulle", "Paris");

            Flight f1 = AddFlightToDbContext("F5346", ap1, ai1, ai1, 50);
            Flight f2 = AddFlightToDbContext("F6788", ap1, ai2, ai2, 33);
            Flight f3 = AddFlightToDbContext("F2235", ap1, ai3, ai4, 120);
            Flight f4 = AddFlightToDbContext("F8542", ap1, ai4, ai2, 45);
            Flight f5 = AddFlightToDbContext("F3435", ap1, ai5, ai1, 57);
            Flight f6 = AddFlightToDbContext("F0283", ap2, ai1, ai4, 80);
            Flight f7 = AddFlightToDbContext("F5234", ap2, ai2, ai5, 24);
            Flight f8 = AddFlightToDbContext("F1234", ap2, ai3, ai5, 78);
            Flight f9 = AddFlightToDbContext("F4682", ap2, ai4, ai2, 134);
            Flight f99 = AddFlightToDbContext("F4682", ap2, ai5, ai2, 134);
            Flight f10 = AddFlightToDbContext("F1344", ap3, ai1, ai3, 47);
            Flight f11 = AddFlightToDbContext("F9732", ap3, ai2, ai2, 76);
            Flight f12 = AddFlightToDbContext("F4663", ap3, ai3, ai1, 89);
            Flight f13 = AddFlightToDbContext("F9765", ap3, ai4, ai5, 110);
            Flight f93 = AddFlightToDbContext("F9765", ap3, ai5, ai5, 110);
            Flight f14 = AddFlightToDbContext("F2235", ap4, ai1, ai2, 120);
            Flight f15 = AddFlightToDbContext("F7532", ap4, ai2, ai2, 90);
            Flight f16 = AddFlightToDbContext("F9676", ap4, ai3, ai5, 110);
            Flight f17 = AddFlightToDbContext("F2344", ap4, ai4, ai3, 120);
            Flight f18 = AddFlightToDbContext("F3476", ap5, ai1, ai3, 90);
            Flight f19 = AddFlightToDbContext("F5675", ap5, ai2, ai1, 50);
            Flight f20 = AddFlightToDbContext("F6576", ap5, ai3, ai2, 33);
            Flight f21 = AddFlightToDbContext("F2tt5", ap5, ai4, ai4, 120);

            Flight f22= AddFlightToDbContext("F3242", ap6, ai1, ai2, 45);
            Flight f23 = AddFlightToDbContext("F4fr5", ap6, ai2, ai1, 57);
            Flight f24 = AddFlightToDbContext("F0er4", ap6, ai3, ai4, 80);
            Flight f25 = AddFlightToDbContext("F535g", ap6, ai4, ai5, 24);
            Flight f26 = AddFlightToDbContext("F1244", ap7, ai1, ai5, 78);
            Flight f27 = AddFlightToDbContext("F4hk2", ap7, ai2, ai2, 134);
            Flight f42 = AddFlightToDbContext("F3242", ap7, ai3, ai2, 45);
            Flight f43 = AddFlightToDbContext("F4fr5", ap7, ai4, ai1, 57);
            Flight f44 = AddFlightToDbContext("F0er4", ap8, ai1, ai4, 80);
            Flight f45 = AddFlightToDbContext("F535g", ap8, ai2, ai5, 24);
            Flight f46 = AddFlightToDbContext("F1244", ap8, ai3, ai5, 78);
            Flight f47 = AddFlightToDbContext("F4hk2", ap8, ai4, ai2, 134);
            Flight f48 = AddFlightToDbContext("F3242", ap9, ai1, ai2, 45);
            Flight f49 = AddFlightToDbContext("F4fr5", ap9, ai2, ai1, 57);
            Flight f50 = AddFlightToDbContext("F0er4", ap9, ai3, ai4, 80);
            Flight f51 = AddFlightToDbContext("F535g", ap10, ai1, ai5, 24);
            Flight f52 = AddFlightToDbContext("F1244", ap10, ai2, ai5, 78);
            Flight f53 = AddFlightToDbContext("F4hk2", ap10, ai3, ai2, 134);
            Flight f28 = AddFlightToDbContext("F1364", ap10, ai4, ai4, 47);
            Flight f29 = AddFlightToDbContext("F95h2", ap11, ai1, ai2, 76);
            Flight f30 = AddFlightToDbContext("F4ws3", ap11, ai2, ai1, 89);
            Flight f31 = AddFlightToDbContext("Fd465", ap11, ai3, ai5, 110);
            Flight f32 = AddFlightToDbContext("F29o5", ap12, ai1, ai3, 120);
            Flight f33 = AddFlightToDbContext("F3ff2", ap12, ai2, ai1, 90);
            Flight f34 = AddFlightToDbContext("F99h6", ap12, ai3, ai4, 110);
            Flight f35 = AddFlightToDbContext("F9044", ap12, ai4, ai2, 120);

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
