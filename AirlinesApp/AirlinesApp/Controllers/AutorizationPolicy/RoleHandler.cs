using AirlinesApp.Db;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesApp.Controllers.AutorizationPolicy
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        private readonly AppDbContext appDbContext;

        public RoleHandler(AppDbContext appDbContextParam)
        {
            appDbContext = appDbContextParam;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            try
            {
                var userName = context.User.Identity.Name;

                var user = appDbContext.User
                    .Where(u => u.UserId == userName)
                    .FirstOrDefault();

                if (user != null && (!requirement.IsAdmin || user.IsAdmin) && user.IsEnabled)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            catch
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
