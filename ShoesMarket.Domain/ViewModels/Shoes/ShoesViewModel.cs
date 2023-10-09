using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ShoesMarket.Domain.ViewModels.Shoes
{
    public class ShoesViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [MinLength(50, ErrorMessage = "Минимальная длина должна быть больше 50 символов")]
        public string Description { get; set; }

        [Display(Name = "Модель")]
        [Required(ErrorMessage = "Укажите модель")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string Model { get; set; }

        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Укажите стоимость")]
        public decimal Price { get; set; }

        [Display(Name = "Тип обуви")]
        [Required(ErrorMessage = "Выберите тип")]
        public string TypeShoes { get; set; }

        public IFormFile Avatar { get; set; }

        public byte[]? Image { get; set; }
    }
}