using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoesMarket.DAL.Interfaces;
using ShoesMarket.Domain.Entity;
using ShoesMarket.Domain.Enum;
using ShoesMarket.Domain.Extencions;
using ShoesMarket.Domain.Response;
using ShoesMarket.Domain.ViewModels.Shoes;
using ShoesMarket.Service.Interfaces;

namespace ShoesMarket.Service.Implementations
{
    public class ShoesService : IShoesService
    {
        private readonly IBaseRepository<Shoes> _shoesRepository;

        public ShoesService(IBaseRepository<Shoes> shoesRepository)
        {
            _shoesRepository = shoesRepository;
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeShoes[])Enum.GetValues(typeof(TypeShoes)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ShoesViewModel>> GetShoes(long id)
        {
            try
            {
                var shoes = await _shoesRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (shoes == null)
                {
                    return new BaseResponse<ShoesViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var data = new ShoesViewModel()
                {
                    Description = shoes.Description,
                    Name = shoes.Name,
                    Price = shoes.Price,
                    TypeShoes = shoes.TypeShoes.GetDisplayName(),
                    Model = shoes.Model,
                    Image = shoes.Avatar,
                };

                return new BaseResponse<ShoesViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ShoesViewModel>()
                {
                    Description = $"[GetShoes] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Dictionary<long, string>>> GetShoes(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<long, string>>();
            try
            {
                var shoeses = await _shoesRepository.GetAll()
                    .Select(x => new ShoesViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Model = x.Model,
                        Price = x.Price,
                        TypeShoes = x.TypeShoes.GetDisplayName()
                    })
                    .Where(x => EF.Functions.Like(x.Name, $"%{term}%"))
                    .ToDictionaryAsync(x => x.Id, t => t.Name);

                baseResponse.Data = shoeses;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<long, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Shoes>> Create(ShoesViewModel model, byte[] imageData)
        {
            try
            {
                var shoes = new Shoes()
                {
                    Name = model.Name,
                    Model = model.Model,
                    Description = model.Description,
                    TypeShoes = (TypeShoes)Convert.ToInt32(model.TypeShoes),
                    Price = model.Price,
                    Avatar = imageData
                };
                await _shoesRepository.Create(shoes);

                return new BaseResponse<Shoes>()
                {
                    StatusCode = StatusCode.OK,
                    Data = shoes
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Shoes>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteShoes(long id)
        {
            try
            {
                var shoes = await _shoesRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (shoes == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "User not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }

                await _shoesRepository.Delete(shoes);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteShoes] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Shoes>> Edit(long id, ShoesViewModel model)
        {
            try
            {
                var shoes = await _shoesRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (shoes == null)
                {
                    return new BaseResponse<Shoes>()
                    {
                        Description = "Shoes not found",
                        StatusCode = StatusCode.ShoesNotFound
                    };
                }

                shoes.Description = model.Description;
                shoes.Model = model.Model;
                shoes.Price = model.Price;
                shoes.Name = model.Name;

                await _shoesRepository.Update(shoes);


                return new BaseResponse<Shoes>()
                {
                    Data = shoes,
                    StatusCode = StatusCode.OK,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Shoes>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Shoes>> GetShoeses()
        {
            try
            {
                var shoeses = _shoesRepository.GetAll().ToList();
                if (!shoeses.Any())
                {
                    return new BaseResponse<List<Shoes>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Shoes>>()
                {
                    Data = shoeses,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Shoes>>()
                {
                    Description = $"[GetShoeses] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
