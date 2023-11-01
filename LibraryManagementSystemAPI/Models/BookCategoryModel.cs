using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystemAPI.Models
{
    [Table("book_categories")]
    public class BookCategoryModel : ModelBase
    {
        [StringLength(100)]
        public string? Category { get; set; }
        [StringLength(100)]
        public string? SubCategory { get; set; }
    }
}
