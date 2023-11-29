using Microsoft.AspNetCore.Identity;
using ProduceDeliveryApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface IUserManager
    {
        Task<IUser> FindByIdAsync(Guid id);
        Task<IEnumerable<IUser>> FindByIdAsync(IEnumerable<Guid> ids);
        Task<IUser> FindByEmailAsync(string email);
        Task<IUser> FindByPhoneNumberAsync(string phoneNo);
        Task<bool> IsEmailConfirmedAsync(IUser user);
        Task<bool> IsPhoneNumberConfirmedAsync(IUser user);
        Task<IIdentityResult> ChangePhoneNumberAsync(IUser user, string phoneNo, string code);
        Task<string> GeneratePasswordResetTokenAsync(IUser user);
        Task<string> GenerateChangePhoneNumberTokenAsync(IUser user, string phoneNo);

        Task<IIdentityResult> ResetPasswordAsync(IUser user, string token, string newPassword);
        Task<bool> VerifyTwoFactorTokenAsync(IUser user, string v, string token);
        Task<IIdentityResult> ChangePasswordAsync(IUser user, string currentPassword, string newPassword);

        Task<IIdentityResult> CreateAsync(IUser user, string password);
        Task<bool> IsInRole(IUser user, RoleType role);
        Task<IIdentityResult> AddToRole(IUser user, RoleType role);
        Task<IIdentityResult> RemoveFromRole(IUser user, RoleType role);
        Task<IIdentityResult> AddToClaim(IUser user, Claim claim);
        Task<IIdentityResult> RemoveFromClaim(IUser user, Claim claim);
        Task<IIdentityResult> UpdateAsync(IUser user);
        Task<IIdentityResult> DeleteAsync(IUser user);
        Task<string> GenerateTwoFactorTokenAsync(IUser user, string tokenProvider);

        //sign in
        Task<SignInResult> PasswordSignInAsync(IUser user, string password);
        Task SignInAsync(IUser user, bool remember);
    }
}
