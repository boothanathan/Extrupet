using Extrupet.BAL.Interfaces;
using Extrupet.BAL.Models;
using Extrupet.BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Extrupet.API.Controllers
{
    [RoutePrefix("Api/User")]
    public class UserController : ApiController
    {
        private readonly IUserService userService = new UserService();
        private readonly ICompanyDataService companyDataService = new CompanyDataService();

        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpPost]
        [Route("CreateUser")]
        public IHttpActionResult CreateUser(UserSet userSet)
        {
            var user = userService.CreateUser(userSet);
            return Ok(user);
        }
        [HttpPost]
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser(UserSet userSet)
        {
            var user = userService.UpdateUser(userSet);
            return Ok(user);
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(UserLogin userLogin)
        {
            var user = userService.Login(userLogin);
            if (user != null)
            {
                return Ok(user);
            }

            return Unauthorized();
        }

    }
}
