using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesApp.Domain
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public Airplane Airplane { get; set; }

        public Airport FromAirport { get; set; }

        public Airport ToAirport { get; set; }
    }
}