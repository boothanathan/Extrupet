using Extrupet.BAL.Interfaces;
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
    }
}
