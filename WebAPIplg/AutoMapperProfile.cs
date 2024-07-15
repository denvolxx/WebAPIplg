using AutoMapper;
using WebAPIplg.DTO.Person;
using WebAPIplg.Models;

namespace WebAPIplg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
        }
    }
}
