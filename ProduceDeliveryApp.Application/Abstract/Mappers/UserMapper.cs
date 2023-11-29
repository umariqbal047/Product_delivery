using AutoMapper;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Application.Accounts.Commands;
using ProduceDeliveryApp.Domain;

namespace ProduceDeliveryApp.Application.Abstract.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<IUser, UserInfo>();

            CreateMap<RegisterClientCmd, UserInfo>();
        }
    }
}
