using System.Linq;
using System.Threading.Tasks;
using ShoesMarket.DAL.Interfaces;
using ShoesMarket.Domain.Entity;

namespace ShoesMarket.DAL.Repositories
{
    public class ShoesRepository : IBaseRepository<Shoes>
    {
        private readonly ApplicationDBContext _db;

        public ShoesRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Create(Shoes entity)
        {
            await _db.Shoeses.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Shoes> GetAll()
        {
            return _db.Shoeses;
        }

        public async Task Delete(Shoes entity)
        {
            _db.Shoeses.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Shoes> Update(Shoes entity)
        {
            _db.Shoeses.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}















//public bool Create(Shoes entity)
//{
//    throw new NotImplementedException();
//}

//public bool Delete(Shoes entity)
//{
//    throw new NotImplementedException();
//}

//public async Task<Shoes> Get(int Id)
//{
//    return await _db.Shoes.FirstOrDefaultAsync(x => x.Id == Id);
//}

//public Shoes GetByName(string name)
//{
//    throw new NotImplementedException();
//}

//public async Task<List<Shoes>> GetAllAsync()
//{
//    return await _db.Shoes.ToListAsync();
//}

//Shoes IBaseRepository<Shoes>.Get(int Id)
//{
//    throw new NotImplementedException();
//}

//IEnumerable<Shoes> IBaseRepository<Shoes>.GetAllAsync()
//{
//    throw new NotImplementedException();
//}
