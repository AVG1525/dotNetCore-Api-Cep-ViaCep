using AspCepAPI.Interfaces;
using AspCepAPI.Models;

namespace AspCepAPI.Services
{
    public class Service : IService
    {
        private readonly ICepService _cepService;
        private readonly IApiCepService _apiCepService;

        public Service(ICepService cepService, IApiCepService apiCepService)
        {
            _cepService = cepService;
            _apiCepService = apiCepService;
        }

        public dynamic ObterCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return null;

            var cepRetorno =_cepService.ObterCep(cep);
            if(cepRetorno == null)
            {
                cepRetorno = _apiCepService.ObterCep(cep);

                if(cepRetorno != null)
                    _cepService.AdicionarCepPesquisa((CepModel)cepRetorno);
            }
            return cepRetorno;
        }

        public dynamic ObterCepsPesquisados()
        {
            return _cepService.ObterCepsPesquisados();
        }

    }
}
