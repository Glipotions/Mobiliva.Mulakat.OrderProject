using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mobiliva.Mulakat.Entities.Concrete
{
    public class Product : BaseEntity
    {
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Category { get; set; }
        [StringLength(50)]
        public string Unit { get; set; }
        //[Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
