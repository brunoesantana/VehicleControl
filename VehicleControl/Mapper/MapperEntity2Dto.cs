﻿using AutoMapper;
using VehicleControl.Business;
using VehicleControl.CrossCutting.DTO.Anuncio;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.DTO.Modelo;
using VehicleControl.CrossCutting.DTO.User;
using VehicleControl.Data.Context;
using VehicleControl.Data.Repository;
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
                .AfterMap((src, dest) => dest.ValorLucro = (src.ValorVenda - src.ValorCompra))
                .AfterMap((src, dest) =>
                {
                    dest.Marca = new MarcaService(new MarcaRepository(new DataContext())).GetMarcaDTOFromMarcaKey(src.MarcaKey);
                })
                .AfterMap((src, dest) =>
                {
                    dest.Modelo = new ModeloService(new ModeloRepository(new DataContext())).GetModeloDTOFromModeloKey(src.ModeloKey);
                });

            CreateMap<User, UserDTO>();
        }
    }
}
