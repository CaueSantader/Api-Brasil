using ApiBrasil.Dtos;
using ApiBrasil.Models;
using AutoMapper;
using System.Reflection.Metadata;

namespace ApiBrasil.Mappings
{
    public class BancoMapping : Profile
    {
        public BancoMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<BancoResponse, BancoModel>();
            CreateMap<BancoModel, BancoResponse>();
        }
        
    }
}
