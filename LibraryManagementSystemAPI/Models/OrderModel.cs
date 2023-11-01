using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystemAPI.Models
{
    [Table("orders")]
    public class OrderModel : ModelBase
    {
        [StringLength(100)]
        public string? RefUser { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? RefBook { get; set; }
        [StringLength(100)]
        public string? BookName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }
    }
}
