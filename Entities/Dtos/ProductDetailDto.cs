namespace Mobiliva.Mulakat.Entities.Dtos
{
    public class ProductDetailDto : IDto
    {
        public long ProductId { get; set; }
        //public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
    }
}
