using Extrupet.BAL.Interfaces;
using Extrupet.BAL.Models;
using Extrupet.BAL.Services;
using Extrupet.BAL.Utilities;
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
        private ExtrupetResponse response;
        
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            var users = userService.GetAllUsers();
            response = new ExtrupetResponse { Status = true, ResponseObject = users };
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateUser")]
        public IHttpActionResult CreateUser(UserSet userSet)
        {
            var user = userService.CreateUser(userSet);
            response = new ExtrupetResponse { Status = true, ResponseObject = user };
            return Ok(response);
        }

        [HttpGet]
        [Route("GetUser/{Id}")]
        public IHttpActionResult GetUser(Guid Id)
        {
            var user = userService.GetUserDetailsGetById(Id);
            response = new ExtrupetResponse { Status = true, ResponseObject = user };
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser(UserSet userSet)
        {
            var user = userService.UpdateUser(userSet);
            response = new ExtrupetResponse { Status = true, ResponseObject = user };
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(UserLogin userLogin)
        {
            var user = userService.Login(userLogin);
            if (user != null)
            {
                response = new ExtrupetResponse { Status = true, ResponseObject = user };
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("ActivationStatus")]
        public IHttpActionResult ActivationStatus(UserActivationStatus userActivationStatus)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUserById(userActivationStatus.UserId);
                if (user != null)
                {
                    user.IsActive = userActivationStatus.Status;
                    var status = userService.UpdateUserActivationStatus(user);
                    response = new ExtrupetResponse { Status = status, Message = "" };
                    return Ok(response);
                }

                return BadRequest();
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public IHttpActionResult UpdatePassword(UserPassword userPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = userService.GetUserById(userPassword.UserId);
                    if (user != null)
                    {
                        var status = userService.UpdatePassword(userPassword);
                        response = new ExtrupetResponse { Status = status, Message = "" };
                        return Ok(response);
                    }

                    return BadRequest(ModelState);
                }

                return BadRequest(ModelState);
            }
            catch (PasswordNotMatchException ex)
            {
                response = new ExtrupetResponse { Status = false, Message = "Wrong old password!" };
                return Ok(response);
            }
        }

    }
}
