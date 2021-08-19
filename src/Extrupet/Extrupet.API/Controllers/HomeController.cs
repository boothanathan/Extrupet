using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Extrupet.API.Controllers
{
    public class HomeController : ApiController
    {
        // GET: Home
        public string Get()
        {
            return "Welcome!";
        }
    }
}