using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.BLL.Abstractions
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetAllCars();
        Task<IBaseResponse<Car>> GetCar(int id);
        Task<IBaseResponse<bool>> AddCar(Car car);
        Task<IBaseResponse<bool>> DeleteCar(int id);
        Task<IBaseResponse<Car>> GetCarByName(string name);
        Task<IBaseResponse<bool>> EditCar(int id, Car model);
    }
}
