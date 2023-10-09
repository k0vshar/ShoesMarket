using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoesMarket.Domain.Enum
{
    public enum TypeShoes
    {
        [Display(Name = "Спортивная обувь")]
        SportShoes = 0,
        [Display(Name = "Обувь для ходьбы")]
        WalkShoes = 1,
        [Display(Name = "Женская обувь")]
        FemaleShoes = 2,
        [Display(Name = "Мужская обувь")]
        MenShoes = 3,
        [Display(Name = "Обувь унисекс")]
        UnisexShoes = 4,
        [Display(Name = "Обувь для бега")]
        SprintShoes = 5
    }
}
