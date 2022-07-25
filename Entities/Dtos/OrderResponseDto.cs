
namespace Mobiliva.Mulakat.Entities.Dtos
{
    public class OrderResponseDto:IDto
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public ICollection<ProductDetailDto> ProductDetails { get; set; }
    }
}
