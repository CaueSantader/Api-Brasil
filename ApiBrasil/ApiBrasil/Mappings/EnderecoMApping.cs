using ApiBrasil.Dtos;
using ApiBrasil.Models;
using AutoMapper;
using System.Reflection.Metadata;

namespace ApiBrasil.Mappings
{
    public class EnderecoMApping : Profile
    {
        public EnderecoMApping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<EnderecoResponse, EnderecoModel>();
            CreateMap<EnderecoModel, EnderecoResponse>();
                
        }

    }
}
