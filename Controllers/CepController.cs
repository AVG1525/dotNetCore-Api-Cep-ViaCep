using AspCepAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspCepAPI.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IService _service;
        public CepController(IService service)
        {
            _service = service;
        }

        [HttpGet("{cep}")]
        public dynamic Get(string cep) {
            var result = _service.ObterCep(cep);

            if (result == null)
                return NotFound();
            return result;
        }

        [HttpGet]
        [Route("Todos")]
        public dynamic Todos() {
            var result =_service.ObterCepsPesquisados();

            if (result == null)
                return NotFound();
            return result;
        }
    }
}
