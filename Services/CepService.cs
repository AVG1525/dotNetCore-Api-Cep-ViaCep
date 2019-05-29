using AspCepAPI.Domain;
using AspCepAPI.Interfaces;
using AspCepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCepAPI.Services
{
    public class CepService : ICepService
    {
        private readonly CepDomain _cepDomain;
        public CepService(CepDomain cepDomain)
        {
            _cepDomain = cepDomain;
        }


        public void AdicionarCepPesquisa(CepModel cep)
        {
            if (ObterCep(cep.cep) == null){

                cep.cep = cep.cep.Replace("-", "");

                _cepDomain.CepModel.Add(cep);
                _cepDomain.SaveChanges();
            }
        }

        public object ObterCep(string cep)
        {
            return _cepDomain.CepModel.SingleOrDefault(x => x.cep.Equals(cep));
        }

        public object ObterCepsPesquisados()
        {
            return _cepDomain.CepModel.ToList();
        }
    }
}
