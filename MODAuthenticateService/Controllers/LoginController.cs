using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODAuthenticateService.Models;
using MODAuthenticateService.Repositories;


namespace MODAuthenticateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repository;
        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("Validate/{email}/{pwd}")]
        public Token Get(string email, string pwd)
        {
            if (_repository.UserLogin(email, pwd) != null)
            {
                User response = _repository.UserLogin(email, pwd);
                return new Token() { message = "User", token = response.User_Id.ToString()};
            }
            else if(_repository.MentorLogin(email,pwd) != null)
            {
                Mentor response = _repository.MentorLogin(email, pwd);
                return new Token() { message = "Mentor", token = response.Mentor_Id.ToString()};
            }
            else if(email=="TechMakerz28" && pwd =="admin")
            {

                return new Token() { message = "Admin", token ="TechMakerz28" };
            }
            else
            {
                return new Token() { message = "Invalid User/Mentor", token = "" };
            }
        }
        public string GetToken()
        {
            return "";
        }

    }
}