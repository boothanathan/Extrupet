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
    public class ValuesController : ApiController
    {
        private readonly IUserService _userService;

        public ValuesController()
        {
            this._userService = new UserService();
        }

        // GET api/values
        public IEnumerable<UserGet> Get()
        {
            var users = _userService.GetUsers();
            return users;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public UserGet Post(UserSet  value)
        {
            return _userService.SaveUsers(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
