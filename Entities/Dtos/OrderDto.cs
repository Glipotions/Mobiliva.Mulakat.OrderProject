namespace Mobiliva.Mulakat.Entities.Dtos
{
    public class OrderDto:BaseDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
