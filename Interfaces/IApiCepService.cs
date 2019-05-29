using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCepAPI.Interfaces
{
    public interface IApiCepService
    {
        dynamic ObterCep(string cep);
    }
}
