using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using ProduceDeliveryApp.Domain.Enums;
using ProduceDeliveryApp.Persistence.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Web.Auth
{
    public class UserManagerDecorator : IUserManager
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserManagerDecorator(UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser> signInManager)
        {
            _manager = manager;
            _signInManager = signInManager;
        }

        public async Task<IUser> FindByIdAsync(Guid id)
        {
            return await _manager.FindByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<IUser>> FindByIdAsync(IEnumerable<Guid> ids)
        {
            var userIds = ids.ToList();
            return await _manager.Users.Where(x => userIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<IUser> FindByEmailAsync(string email)
        {
            return await _manager.FindByEmailAsync(email);
        }

        public Task<bool> IsEmailConfirmedAsync(IUser user)
        {
            return _manager.IsEmailConfirmedAsync(user as ApplicationUser);
        }

        public Task<string> GeneratePasswordResetTokenAsync(IUser user)
        {
            return _manager.GeneratePasswordResetTokenAsync(user as ApplicationUser);
        }

        public async Task<IUser> FindByPhoneNumberAsync(string phone)
        {
            return await _manager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
        }

        public Task<bool> IsPhoneNumberConfirmedAsync(IUser user)
        {
            return _manager.IsPhoneNumberConfirmedAsync(user as ApplicationUser);
        }

        public async Task<IIdentityResult> ChangePhoneNumberAsync(IUser user, string phone, string code)
        {
            return (await _manager.ChangePhoneNumberAsync(user as ApplicationUser, phone, code)).ToResult();
        }

        public Task<string> GenerateChangePhoneNumberTokenAsync(IUser user, string phone)
        {
            return _manager.GenerateChangePhoneNumberTokenAsync(user as ApplicationUser, phone);
        }
        public async Task<bool> VerifyTwoFactorTokenAsync(IUser user, string tokenProvider, string token)
        {
            return await _manager.VerifyTwoFactorTokenAsync(user as ApplicationUser, tokenProvider, token);
        }

        public async Task<string> GenerateTwoFactorTokenAsync(IUser user, string tokenProvider)
        {
            return await _manager.GenerateTwoFactorTokenAsync(user as ApplicationUser, tokenProvider);
        }

        public async Task<IIdentityResult> ResetPasswordAsync(IUser user, string token, string newPassword)
        {
            return (await _manager.ResetPasswordAsync(user as ApplicationUser, token, newPassword)).ToResult();
        }

        public async Task<IIdentityResult> ChangePasswordAsync(IUser user, string currentPassword, string newPassword)
        {
            return (await _manager.ChangePasswordAsync(user as ApplicationUser, currentPassword, newPassword)).ToResult();
        }

        public async Task<IIdentityResult> CreateAsync(IUser user, string password)
        {
            return (await _manager.CreateAsync(user as ApplicationUser, password)).ToResult();
        }

        public Task<bool> IsInRole(IUser user, RoleType role)
        {
            return _manager.IsInRoleAsync(user as ApplicationUser, role.ToString());
        }

        public async Task<IIdentityResult> AddToRole(IUser user, RoleType role)
        {
            return (await _manager.AddToRoleAsync(user as ApplicationUser, role.ToString())).ToResult();
        }

        public async Task<IIdentityResult> RemoveFromRole(IUser user, RoleType role)
        {
            return (await _manager.RemoveFromRoleAsync(user as ApplicationUser, role.ToString())).ToResult();
        }
        public async Task<IIdentityResult> AddToClaim(IUser user, Claim claim)
        {
            return (await _manager.AddClaimAsync(user as ApplicationUser, claim)).ToResult();
        }

        public async Task<IIdentityResult> RemoveFromClaim(IUser user, Claim claim)
        {
            return (await _manager.RemoveClaimAsync(user as ApplicationUser, claim)).ToResult();
        }
        public async Task<IIdentityResult> UpdateAsync(IUser user)
        {
            return (await _manager.UpdateAsync(user as ApplicationUser)).ToResult();
        }

        public async Task<IIdentityResult> DeleteAsync(IUser user)
        {
            return (await _manager.DeleteAsync(user as ApplicationUser)).ToResult();
        }

        //sign in
        public async Task<SignInResult> PasswordSignInAsync(IUser user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user as ApplicationUser, password, true);
        }

        public async Task SignInAsync(IUser user, bool remember)
        {
            await _signInManager.SignInAsync(user as ApplicationUser, remember);
        }
    }
}
