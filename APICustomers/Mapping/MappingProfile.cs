using APICustomers.DTOs;
using AutoMapper;
using BackendAPI.Domain.Entities;

namespace APICustomers.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonaDto, Persona>();
        CreateMap<ClienteDto, Cliente>();
    }
}
