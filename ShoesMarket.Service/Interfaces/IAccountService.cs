using ShoesMarket.Domain.Models;
using ShoesMarket.Domain.Response;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoesMarket.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}
