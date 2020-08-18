using System;
using VehicleControl.CrossCutting.DTO.Anuncio;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.DTO.Modelo;
using VehicleControl.CrossCutting.DTO.User;
using VehicleControl.Domain;

namespace Services.Test.Mock
{
    public class MockBuilder
    {
        public UserInsertDTO BuilderUserInsertDTO()
        {
            return new UserInsertDTO
            {
                Username = $"usuario{GetRandomNumber()}",
                Password = "12345"
            };
        }

        public UserUpdateDTO BuilderUpdateUserDTO(User user)
        {
            return new UserUpdateDTO
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        public MarcaInsertDTO BuildMarcaInsertDTO()
        {
            return new MarcaInsertDTO
            {
                Name = $"marca{GetRandomNumber()}",
                Description = "teste"
            };
        }

        public MarcaUpdateDTO BuilderUpdateMarcaDTO(Marca marca)
        {
            return new MarcaUpdateDTO
            {
                Id = marca.Id,
                Name = marca.Name,
                Description = marca.Description
            };
        }

        public ModeloInsertDTO BuilderModeloInsertDTO()
        {
            return new ModeloInsertDTO
            {
                Name = $"modelo{GetRandomNumber()}",
                Detail = "teste 1.0"
            };
        }

        public ModeloUpdateDTO BuilderUpdateModeloDTO(Modelo modelo)
        {
            return new ModeloUpdateDTO
            {
                Id = modelo.Id,
                Name = modelo.Name,
                Detail = modelo.Detail
            };
        }

        public AnuncioInsertDTO BuilderAnuncioInsertDTO(Guid marcaKey, Guid modeloKey)
        {
            return new AnuncioInsertDTO
            {
                Ano = 1,
                ValorCompra = 1,
                ValorVenda = 1,
                Cor = "Preto",
                TipoCombustivel = "Gasolina",
                DataVenda = DateTime.Now,
                MarcaKey = marcaKey,
                ModeloKey = modeloKey,
            };
        }

        public AnuncioUpdateDTO BuilderUpdateAnuncioDTO(Anuncio anuncio)
        {
            return new AnuncioUpdateDTO
            {
                Id = anuncio.Id,
                Ano = anuncio.Ano,
                ValorCompra = anuncio.ValorCompra,
                ValorVenda = anuncio.ValorVenda,
                TipoCombustivel = anuncio.TipoCombustivel,
                Cor = anuncio.Cor,
                DataVenda = anuncio.DataVenda,
                MarcaKey = anuncio.MarcaKey,
                ModeloKey = anuncio.ModeloKey
            };
        }

        public int GetRandomNumber()
        {
            return new Random().Next(1, 99999);
        }
    }
}
