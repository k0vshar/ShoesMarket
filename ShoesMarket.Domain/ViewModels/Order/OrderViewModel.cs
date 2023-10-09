namespace ShoesMarket.Domain.ViewModels.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }

        public string ShoesName { get; set; }

        public string Model { get; set; }

        public string TypeShoes { get; set; }

        public byte[]? Image { get; set; }

        public string Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
