using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.DataRead.UsersInfo.Queries;
using ProduceDeliveryApp.DataRead.UsersInfo.ReadModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.DataRead.UsersInfo.QueryHandlers
{
    public class GetSingleUserHandler : IRequestHandler<GetUserProfile, UserProfileReadModel>
    {
        private readonly IProduceDeliveryAppDataContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public GetSingleUserHandler(IProduceDeliveryAppDataContext context, IMapper mapper, ICurrentUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<UserProfileReadModel> Handle(GetUserProfile request, CancellationToken token)
        {
            var user = await _context.UserInfos.Where(x => x.Id == _currentUser.Id)
                   .FirstOrDefaultAsync();

            return _mapper.Map<Domain.UserInfo, UserProfileReadModel>(user);
        }
    }
}
