using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesApp.Controllers.AutorizationPolicy
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public bool IsAdmin { get; }

        public RoleRequirement(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
    }
}
