using AutoMapper;
using ProduceDeliveryApp.DataRead.UsersInfo.ReadModels;
using ProduceDeliveryApp.Domain;
using ProduceDeliveryApp.Domain.Enums;

namespace ProduceDeliveryApp.DataRead.Abstract.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserInfo, UserReadModel>()
                 .ForMember(x => x.RoleId, y => y.MapFrom(z => z.RoleId));

            CreateMap<UserInfo, UserProfileReadModel>()
                .ForMember(x => x.RoleId, y => y.MapFrom(z => z.RoleId));
        }
    }
}
