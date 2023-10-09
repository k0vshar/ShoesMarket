using ShoesMarket.Domain.Response;
using ShoesMarket.Domain.ViewModels.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoesMarket.Service.Interfaces
{
    public interface IBasketService
    {
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);

        Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id);
    }
}
