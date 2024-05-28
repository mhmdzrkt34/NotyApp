
using AutoMapper;
using NotyApp.api.Dtos;
using NotyApp.api.models;
namespace NotyApp.api.Mappers
{
    public class AutoMapperProfile : Profile
    {

        public  AutoMapperProfile()
        {

            CreateMap<User, UserDto>();

            CreateMap<Role, RoleDto>();

            CreateMap<UserRole, UserRoleDto>();
            CreateMap<Message, MessageDto>();   

            CreateMap<Contact, ContactDto>();




       
        }
    }
}
