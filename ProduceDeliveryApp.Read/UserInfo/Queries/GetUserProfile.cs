using MediatR;
using ProduceDeliveryApp.DataRead.UsersInfo.ReadModels;
using System;

namespace ProduceDeliveryApp.DataRead.UsersInfo.Queries
{
    public class GetUserProfile : IRequest<UserProfileReadModel>
    {
        public GetUserProfile(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
