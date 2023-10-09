using ShoesMarket.Domain.Entity;
using System.Threading.Tasks;

namespace ShoesMarket.DAL.Interfaces
{
    public interface IShoesRepository : IBaseRepository<Shoes>
    {
        Task<Shoes> GetByName(string name);
    }
}
