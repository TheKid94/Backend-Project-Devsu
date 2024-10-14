using APIBankConsult.DTOs;
using AutoMapper;
using BackendAPI.Domain.Entities;

namespace APIBankConsult.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CuentaDto, Cuenta>();
        CreateMap<MovimientoDto, Movimiento>();
    }
}
