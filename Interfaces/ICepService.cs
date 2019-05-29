using AspCepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCepAPI.Interfaces
{
    public interface ICepService
    {
        object ObterCep(string cep);

        object ObterCepsPesquisados();

        void AdicionarCepPesquisa(CepModel cep);
    }
}
