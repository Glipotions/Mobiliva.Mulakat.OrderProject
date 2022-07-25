
namespace Mobiliva.Mulakat.Entities.Concrete
{
    public class Order : BaseEntity
    {
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(100)]
        public string CustomerEmail { get; set; }
        [StringLength(20)]
        public string CustomerGSM { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
