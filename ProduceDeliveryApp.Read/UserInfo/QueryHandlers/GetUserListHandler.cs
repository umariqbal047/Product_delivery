using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.DataRead.UsersInfo.Queries;
using ProduceDeliveryApp.DataRead.UsersInfo.ReadModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.DataRead.UsersInfo.QueryHandlers
{
    public class GetUserListHandler : IRequestHandler<GetUserList, IEnumerable<UserReadModel>>
    {
        private readonly IProduceDeliveryAppDataContext _context;
        private readonly IMapper _mapper;
        public GetUserListHandler(IProduceDeliveryAppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadModel>> Handle(GetUserList request, CancellationToken token)
        {
            var users = await _context.UserInfos.Where(x => x.RoleId > 0).ToListAsync();

            var userList=  _mapper.Map<IEnumerable<Domain.UserInfo>, IEnumerable<UserReadModel>>(users);
            return userList;
        }
    }
}
