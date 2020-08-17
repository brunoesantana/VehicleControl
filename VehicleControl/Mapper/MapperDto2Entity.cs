using AutoMapper;
using VehicleControl.CrossCutting.DTO.Anuncio;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.DTO.Modelo;
using VehicleControl.CrossCutting.DTO.User;
using VehicleControl.CrossCutting.Helper;
using VehicleControl.Domain;

namespace VehicleControl.Mapper
{
    public class MapperDto2Entity : Profile
    {
        public MapperDto2Entity()
        {
            CreateMap<MarcaInsertDTO, Marca>();
            CreateMap<MarcaUpdateDTO, Marca>();

            CreateMap<ModeloInsertDTO, Modelo>();
            CreateMap<ModeloUpdateDTO, Modelo>();

            CreateMap<AnuncioInsertDTO, Anuncio>();
            CreateMap<AnuncioUpdateDTO, Anuncio>();

            CreateMap<UserInsertDTO, User>()
                .ForMember(to => to.Password, map => map.MapFrom(from => EncryptHelper.EncryptPassword(from.Password)));

            CreateMap<UserUpdateDTO, User>();
        }
    }
}
