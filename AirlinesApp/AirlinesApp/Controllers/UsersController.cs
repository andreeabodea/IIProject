using AirlinesApp.Db;
using AirlinesApp.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlinesApp.Controllers
{
    

        [Authorize(Policy = "Admin")]
        public class UsersController : Controller
        {
            private const string adminUserAccount = "admin";
            private readonly AppDbContext appDbContext;

            public UsersController(AppDbContext appDbContextParam)
            {
                appDbContext = appDbContextParam;
            }

            protected void AddErrorToModelState(string code, string description)
            {
                ModelState.TryAddModelError(code, description);
            }

            [HttpGet]
            [Route("users")]
            public IActionResult GetAll()
            {
                    List<User> users = appDbContext.User
                        .Select(u => u)
                        .OrderBy(u => u.Id)
                        .ToList();

                    return new ObjectResult(users)
                    {
                        StatusCode = StatusCodes.Status200OK
                    }; 
            }

            [HttpPost]
            [Authorize(Policy = "Admin")]
            [Route("users")]
            public IActionResult Create([FromBody]UserAddDTO model)
            {
                    bool userWithTheAccountExists = appDbContext.User
                        .Select(u => u)
                        .Where(u => u.UserId == model.UserId)
                        .Any(u => u.UserId == model.UserId);

                    if (userWithTheAccountExists)
                    {
                        AddErrorToModelState("CannotCreateUser", "A user with the given account already exists. Cannot create new user with same account.");
                        return new BadRequestObjectResult(ModelState);
                    }

                    appDbContext.User.Add(new User
                    {
                        UserId = model.UserId,
                        IsEnabled = model.IsEnabled,
                        IsAdmin = model.IsAdmin
                    });
                    appDbContext.SaveChanges();

                    return Ok();    
            }

            [HttpPut]
            [Authorize(Policy = "Admin")]
            [Route("users/{userIdToUpdate}")]
            public IActionResult Update(int userIdToUpdate, [FromBody]UserEditDTO model)
            {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    User userToUpdate = appDbContext.User.FirstOrDefault(u => u.Id == userIdToUpdate);

                    if (userToUpdate.UserId == adminUserAccount)
                    {
                        AddErrorToModelState("CannotEditAdmin", "Cannot edit the default admin.");
                        return new BadRequestObjectResult(ModelState);
                    }

                    userToUpdate.UserId = model.UserId;
                    userToUpdate.IsEnabled = model.IsEnabled;
                    userToUpdate.IsAdmin = model.IsAdmin;

                    appDbContext.SaveChanges();

                    return Ok();    
            }
           
            [HttpDelete]
            [Authorize(Policy = "Admin")]
            [Route("users/{userIdToDelete}")]
            public IActionResult Delete(int userIdToDelete)
            {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var currentlyLoogedInUserAccount = this.User.Identity.Name;

                    User theUserToDelete = appDbContext.User.Find(userIdToDelete);
                    if (theUserToDelete == null)
                    {
                        AddErrorToModelState("NoUser", "The user was not found to be delete.");
                        return new BadRequestObjectResult(ModelState);
                    }

                    bool deletingCurrentlyLoggedInUser = string.Equals(theUserToDelete.UserId, currentlyLoogedInUserAccount, StringComparison.CurrentCultureIgnoreCase);

                    if (deletingCurrentlyLoggedInUser)
                    {
                        AddErrorToModelState("CannotDeleteYourself", "One cannot delete itself.");
                        return new BadRequestObjectResult(ModelState);
                    }

                    if (theUserToDelete.UserId == adminUserAccount)
                    {
                        AddErrorToModelState("CannotDeleteAdmin", "Cannot delete the default admin.");
                        return new BadRequestObjectResult(ModelState);
                    }

                    appDbContext.User.Remove(theUserToDelete);
                    appDbContext.SaveChanges();

                    return Ok();
            }

            [Route("currentUser")]
            public IActionResult GetCurrentUser()
            {
                var currentlyLoogedInUserAccount = this.User.Identity.Name;

                    User currentUser = appDbContext.User
                        .Where(cu => cu.UserId == currentlyLoogedInUserAccount)
                        .FirstOrDefault();

                    return new ObjectResult(currentUser)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
            }

        }

}



