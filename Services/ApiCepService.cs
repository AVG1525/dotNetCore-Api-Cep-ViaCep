using AspCepAPI.Interfaces;
using AspCepAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspCepAPI.Services
{
    public class ApiCepService : IApiCepService
    {
        public dynamic ObterCep(string cep) {
            HttpClient httpClient = new HttpClient();

            // base da nova HttpCliente->Uri criada
            httpClient.BaseAddress =new Uri("https://viacep.com.br/ws/");

            var result = httpClient.GetAsync($"{cep}/json").Result.Content.ReadAsStringAsync().Result;
            if (result != null)
                return JsonConvert.DeserializeObject<CepModel>(result);
            return null;
        }

    }
}
