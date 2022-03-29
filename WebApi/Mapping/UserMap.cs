using AutoMapper;
using WebApi.Models;
using WebApi.Models.InputModels;

namespace WebApi.Mapping
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<UserInputModel, User>().ReverseMap();
        }
    }
}
