using ShoesMarket.Domain.Entity;
using ShoesMarket.Domain.Response;
using ShoesMarket.Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesMarket.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<Order>> Create(CreateOrderViewModel model);

        Task<IBaseResponse<bool>> Delete(long id);
    }
}
