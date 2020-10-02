using Microsoft.AspNetCore.Identity;
using MyStore.Web.Data.Entities;
using MyStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user); //método p/ fazer update do user

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword); //método p/ fazer alteração da password

        Task<SignInResult> ValidatePasswordAsync(User user, string password); //vai apenas validar, vai ver se user bate certo com password
        
        Task CheckRoleAsync(string roleName);
        
        Task AddUserToRoleAsync(User user, string roleName);
        
        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userId);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);
    }
}
