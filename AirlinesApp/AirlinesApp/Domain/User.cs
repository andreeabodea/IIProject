using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesApp.Domain
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string UserId { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsAdmin { get; set; }

        public bool DefaultUser { get; set; }
    }
}
