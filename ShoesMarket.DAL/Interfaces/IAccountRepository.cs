using ShoesMarket.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoesMarket.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<ClaimsIdentity> Register(RegisterViewModel model);
        Task<ClaimsIdentity> Login(LoginViewModel model);
    }
}
