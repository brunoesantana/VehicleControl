using AutoMapper;
using VehicleControl.CrossCutting.DTO.Anuncio;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.DTO.Modelo;
using VehicleControl.CrossCutting.DTO.User;
using VehicleControl.Domain;

namespace VehicleControl.Mapper
{
    public class MapperEntity2Dto : Profile
    {
        public MapperEntity2Dto()
        {
            CreateMap<Marca, MarcaDTO>();
            CreateMap<Modelo, ModeloDTO>();
            CreateMap<Anuncio, AnuncioDTO>()
                .AfterMap((src, dest) => dest.ValorLucro = (src.ValorVenda - src.ValorCompra));

            CreateMap<User, UserDTO>();
        }
    }
}
