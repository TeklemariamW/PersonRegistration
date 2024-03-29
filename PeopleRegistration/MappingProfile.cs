using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace PeopleRegistration
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            //Map FROM-object => TO-object
            CreateMap<Person, PersonDto>();
            CreateMap<Person, PersonDetailsDto>();
            CreateMap<PersonForCreationDto, Person>();
            CreateMap<PersonForUpdateDto, Person>();
        }
    }
}
