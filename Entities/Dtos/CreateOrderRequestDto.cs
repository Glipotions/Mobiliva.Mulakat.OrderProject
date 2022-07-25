
namespace Mobiliva.Mulakat.Entities.Dtos
{
    public class CreateOrderRequestDto:IDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public ICollection<ProductDetailDto> ProductDetails { get; set; }
    }
}
