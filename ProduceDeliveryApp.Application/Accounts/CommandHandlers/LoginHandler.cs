using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Application.Accounts.Commands;

namespace ProduceDeliveryApp.Application.Accounts.CommandHandlers
{
    public class LoginHandler : IRequestHandler<LoginCmd, (bool status, string error)>
    {
        private readonly IUserManager _userManager;
        private readonly IMediator _mediator;

        public LoginHandler(
            IUserManager userManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<(bool status, string error)> Handle(LoginCmd request, CancellationToken token)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return (false, "Invalid login attempt");
            }

            var result = await _userManager.PasswordSignInAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return (false, "Invalid login attempt");
            }

            //sign in 
            await _userManager.SignInAsync(user, request.RememberMe);

            //await _mediator.Publish(new Message($"User with id {user.Id} has been created"), token);
            return (true, null);
        }
    }

}
