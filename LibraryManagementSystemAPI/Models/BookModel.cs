using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystemAPI.Models
{
    [Table("books")]
    public class BookModel : ModelBase
    {
        [StringLength(100)]
        public string? Title { get; set; } 
        public string? Description { get; set; }
        [StringLength(100)]
        public string? Files { get; set; }
        [StringLength(100)]
        public string? Author { get; set; }
        public float Price { get; set; } = 0;
        public bool Ordered { get; set; } = false;
        [StringLength(100)]
        public string? RefCategory { get; set; }
        public BookCategoryModel Category { get; set; } = new BookCategoryModel();
    }
}

