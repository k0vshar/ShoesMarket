using ShoesMarket.Domain.Entity;
using ShoesMarket.Domain.Response;
using ShoesMarket.Domain.ViewModels.Shoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoesMarket.Service.Interfaces
{
    public interface IShoesService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();

        IBaseResponse<List<Shoes>> GetShoeses();

        Task<IBaseResponse<ShoesViewModel>> GetShoes(long id);

        Task<BaseResponse<Dictionary<long, string>>> GetShoes(string term);

        Task<IBaseResponse<Shoes>> Create(ShoesViewModel shoes, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteShoes(long id);

        Task<IBaseResponse<Shoes>> Edit(long id, ShoesViewModel model);
    }
}
