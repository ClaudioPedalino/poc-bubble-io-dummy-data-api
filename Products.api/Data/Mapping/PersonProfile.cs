using AutoMapper;
using Products.api.Entities;
using Products.api.Models;

namespace Products.api.Data.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}