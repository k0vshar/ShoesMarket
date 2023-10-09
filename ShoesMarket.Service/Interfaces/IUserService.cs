using ShoesMarket.Domain.Entity;
using ShoesMarket.Domain.Response;
using ShoesMarket.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesMarket.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(UserViewModel model);

        BaseResponse<Dictionary<int, string>> GetRoles();

        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(long id);
    }
}
