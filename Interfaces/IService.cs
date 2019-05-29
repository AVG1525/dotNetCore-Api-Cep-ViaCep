using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCepAPI.Interfaces
{
    public interface IService
    {
        dynamic ObterCep(string cep);

        dynamic ObterCepsPesquisados();
    }
}
