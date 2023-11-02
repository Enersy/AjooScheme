using AjooScheme.Domain.Dtos.Account;
using AjooScheme.Domain.Models;

namespace AjooScheme.BusinessLogic.Interface
{
    public interface IAccount
    {
        Task<APIResponse<TokenDto>> Login(LoginDto request);
        Task<APIResponse<UserDto>> CreateRegistration(RegistrationDto request);
    }
}
