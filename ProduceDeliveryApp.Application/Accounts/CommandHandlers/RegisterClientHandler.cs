using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Application.Accounts.Commands;
using ProduceDeliveryApp.Domain;
using ProduceDeliveryApp.Domain.Enums;

namespace ProduceDeliveryApp.Application.Accounts.CommandHandlers
{
    public class RegisterClientHandler : IRequestHandler<RegisterClientCmd, Guid>
    {
        private readonly IUserManager _userManager;
        private readonly IUserFactory _factory;
        private readonly ITransactionManager _transactionManager;
        private readonly IProduceDeliveryAppDataContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RegisterClientHandler(
            IUserManager userManager,
            ITransactionManager transactionManager,
            IUserFactory factory,
            IProduceDeliveryAppDataContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _userManager = userManager;
            _transactionManager = transactionManager;
            _factory = factory;
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(RegisterClientCmd request, CancellationToken token)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                //throw new IncorrectRequestException("This email already exists");
            }

            //custom mapping for aspnet Users table
            using (var tr = await _transactionManager.BeginTransactionAsync(token))
            {
                user = _factory.CreateUser(
                    id: Guid.NewGuid(),
                    userName: request.Email,
                    email: request.Email,
                    //phoneNumber: formattedPhone,
                    isActive: true,
                    emailConfirmed: true);

                var creationResult = await _userManager.CreateAsync(user, request.Password);
                if (!creationResult.Succeeded)
                {
                    //throw new IncorrectRequestException(creationResult.GetErrorMessage());
                }

                var addToRoleResult = await _userManager.AddToRole(user, RoleType.Client);
                if (!addToRoleResult.Succeeded)
                {
                    //throw new IncorrectRequestException(addToRoleResult.GetErrorMessage());
                }

                var profile = _mapper.Map<IUser, UserInfo>(user);
                profile = _mapper.Map<RegisterClientCmd, UserInfo>(request);

                //custom mapping for userInfo table
                profile.RoleId = (byte)RoleType.Client;
                profile.UserId = user.Id;
                profile.Id = user.Id;
                profile.IsActive = true;

                profile.CreatedOn = DateTime.UtcNow;
                profile.CreatedBy = profile.UserId;

                await _context.UserInfos.AddAsync(profile, token);
                await _context.SaveChangesAsync(token);

                tr.Commit();
            }

            //await _mediator.Publish(new Message($"User with id {user.Id} has been created"), token);

            return user.Id;
        }
    }

}
