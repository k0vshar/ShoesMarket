using ShoesMarket.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesMarket.Domain.Entity
{
    public class Shoes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public TypeShoes TypeShoes { get; set; }

        public byte[]? Avatar { get; set; }
    }
}
