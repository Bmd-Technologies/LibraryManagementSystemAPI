using AutoMapper;
using LibraryManagementSystemAPI.Dto;
using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Shared.Mapping
{
    public class MappingService : Profile
    {
        public MappingService()
        {

            CreateMap<UserModel, UserDto>().ReverseMap();
        }


    }
}
