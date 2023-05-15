using ApiBrasil.Dtos;
using ApiBrasil.Interfaces;
using AutoMapper;

namespace ApiBrasil.Services
{
    public class BancoService : IBancoService
    {
        private readonly IMapper mapper;

        private readonly IBrasilApi brasilApi;

        public BancoService(IMapper mapper, IBrasilApi brasilApi)
        {
            this.mapper = mapper;
            this.brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<List<BancoResponse>>> BuscarTodos()
        {
            var Bancos = await brasilApi.BuscarTodosBancos();
            return mapper.Map<ResponseGenerico<List<BancoResponse>>>(Bancos);
        }


        async Task<ResponseGenerico<BancoResponse>> IBancoService.BuscarBanco(string codigoBanco)
        {
            var Banco = await brasilApi.BuscarBanco(codigoBanco);
            return mapper.Map<ResponseGenerico<BancoResponse>>(Banco);
        }
    }
}
