using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesApp.Controllers
{
    public class UserEditDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsAdmin { get; set; }
    }
}
