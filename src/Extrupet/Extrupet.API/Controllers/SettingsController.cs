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
        private readonly IGradeService gradeService = new GradeService();
        private ExtrupetResponse response;
        
        [HttpGet]
        [Route("GetUserRoles")]
        public IHttpActionResult GetUserRoles()
        {
            var roles = userRoleMasterService.GetUserRoles();
            response = new ExtrupetResponse { Status = true, ResponseObject = roles };
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCompanyData")]
        public IHttpActionResult GetCompanyData()
        {
            IEnumerable<CompanyDataGet> companies = companyDataService.GetCompanyData();
            response = new ExtrupetResponse { Status = true, ResponseObject = companies };
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateCompanyData")]
        public IHttpActionResult UpdateCompanyData(CompanyDataSet companyDataSet)
        {
            if (ModelState.IsValid)
            {
                var companyDataGet = companyDataService.SaveCompanyData(companyDataSet);
                response = new ExtrupetResponse { Status = true, ResponseObject = companyDataGet };
                return Ok(response);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllGradeTypes")]
        public IHttpActionResult GetAllGradeTypes()
        {
            var grades = gradeService.GetAllGradeTypeMasters();
            response = new ExtrupetResponse { Status = true, ResponseObject = grades };
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveGradetype")]
        public IHttpActionResult SaveGradetype(GradeTypeSet gradeTypeSet)
        {
            if (ModelState.IsValid)
            {
                var companyDataGet = gradeService.AddOrUpdateGradeTypeMaster(gradeTypeSet);
                response = new ExtrupetResponse { Status = true, ResponseObject = companyDataGet };
                return Ok(response);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllGrades")]
        public IHttpActionResult GetAllGrades()
        {
            var grades = gradeService.GetAllGradeMasters();
            response = new ExtrupetResponse { Status = true, ResponseObject = grades };
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveGrade")]
        public IHttpActionResult SaveGrade(GradeSet gradeSet)
        {
            if (ModelState.IsValid)
            {
                var companyDataGet = gradeService.AddOrUpdateGradeMaster(gradeSet);
                response = new ExtrupetResponse { Status = true, ResponseObject = companyDataGet };
                return Ok(response);
            }

            return BadRequest();
        }

    }
}
