using ApiBrasil.Dtos;
using ApiBrasil.Models;

namespace ApiBrasil.Interfaces
{
    public interface IEnderecoService
    {
        Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);

    }
}
