using BusinessLogic.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IAccountService
    {
        Task Register(RegisterModel model);
        Task<LoginModelResponse> Login(LoginModel model, string? IpAddress );
        Task Logout(LogoutModel model);
        Task<LoginModelResponse> Refresh(string refreshToken, string? IpAddress);

    }
}
