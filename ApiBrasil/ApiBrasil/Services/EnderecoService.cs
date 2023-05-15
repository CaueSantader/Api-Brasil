using ApiBrasil.Dtos;
using ApiBrasil.Interfaces;
using AutoMapper;

namespace ApiBrasil.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper mapper;

        private readonly IBrasilApi brasilApi;

        public EnderecoService(IMapper mapper, IBrasilApi brasilApi)
        {
            this.mapper = mapper;
            this.brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep)
        {
            var endereco = await brasilApi.BuscarEnderecoPorCEP(cep);
            return mapper.Map<ResponseGenerico<EnderecoResponse>>(endereco);
        }
    }
}
 