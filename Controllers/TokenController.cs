using AspCepAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspCepAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromHeader] CepModel request)
        {
            //var TokenRequest = Request.Headers["SecurityKey"];
            if (request.cep == "743ECFF0")
            {
                var token = "743ECFF0";

                return Ok(new {
                    token =(token)
                });
            }
            return BadRequest();
        }
    }
}
