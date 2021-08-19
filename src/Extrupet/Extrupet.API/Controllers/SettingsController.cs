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
        private readonly ISettingsService settingsService = new SettingsService();
        private ExtrupetResponse response;
        
        [HttpGet]
        [Route("GetUserRoles")]
        public IHttpActionResult GetUserRoles()
        {
            var roles = settingsService.GetUserRoles();
            response = new ExtrupetResponse { Status = true, ResponseObject = roles };
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCompanyData")]
        public IHttpActionResult GetCompanyData()
        {
            IEnumerable<CompanyDataGet> companies = settingsService.GetCompanyData();
            response = new ExtrupetResponse { Status = true, ResponseObject = companies };
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateCompanyData")]
        public IHttpActionResult UpdateCompanyData(CompanyDataSet companyDataSet)
        {
            if (ModelState.IsValid)
            {
                var companyDataGet = settingsService.SaveCompanyData(companyDataSet);
                response = new ExtrupetResponse { Status = true, ResponseObject = companyDataGet };
                return Ok(response);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllGradeTypes")]
        public IHttpActionResult GetAllGradeTypes()
        {
            var grades = settingsService.GetAllGradeTypeMasters();
            response = new ExtrupetResponse { Status = true, ResponseObject = grades };
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveGradetype")]
        public IHttpActionResult SaveGradetype(GradeTypeSet gradeTypeSet)
        {
            if (ModelState.IsValid)
            {
                var companyDataGet = settingsService.AddOrUpdateGradeTypeMaster(gradeTypeSet);
                response = new ExtrupetResponse { Status = true, ResponseObject = companyDataGet };
                return Ok(response);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllGrades")]
        public IHttpActionResult GetAllGrades()
        {
            var grades = settingsService.GetAllGradeMasters();
            response = new ExtrupetResponse { Status = true, ResponseObject = grades };
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveGrade")]
        public IHttpActionResult SaveGrade(GradeSet gradeSet)
        {
            if (ModelState.IsValid)
            {
                var companyDataGet = settingsService.AddOrUpdateGradeMaster(gradeSet);
                response = new ExtrupetResponse { Status = true, ResponseObject = companyDataGet };
                return Ok(response);
            }

            return BadRequest();
        }

    }
}
