using System.ComponentModel.DataAnnotations.Schema;

namespace Mobiliva.Mulakat.Entities.Concrete
{
    public class OrderDetail : BaseEntity
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        //[Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        //[Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
