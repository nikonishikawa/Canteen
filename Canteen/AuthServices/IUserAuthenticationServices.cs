using Canteen.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.AuthServices
{
    public interface IUserAuthenticationServices
    {
        Task<UserLoginDto> LoginAccount(RegisterUser login);
        Task<string> RegisterAdmin(RegisterUser register);
        Task<string> RegisterUser(RegisterUser register);
    }
}