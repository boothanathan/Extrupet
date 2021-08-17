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
    [RoutePrefix("Api/Settings")]
    public class SettingsController : ApiController
    {
        private readonly IUserRoleMasterService userRoleMasterService = new UserRoleMasterService();
        private readonly ICompanyDataService companyDataService = new CompanyDataService();

        [HttpGet]
        [Route("GetUserRoles")]
        public IHttpActionResult GetUserRoles()
        {
            return Ok(userRoleMasterService.GetUserRoles());
        }

        [HttpGet]
        [Route("GetCompanyData")]
        public IHttpActionResult GetCompanyData()
        {
            return Ok(companyDataService.GetCompanyData());
        }

        [HttpPost]
        [Route("UpdateCompanyData")]
        public IHttpActionResult UpdateCompanyData(CompanyDataSet companyDataSet)
        {
            if (ModelState.IsValid)
            {
                return Ok(companyDataService.SaveCompanyData(companyDataSet));
            }

            return BadRequest();
        }


    }
}
