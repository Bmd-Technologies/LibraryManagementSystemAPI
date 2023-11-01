using LibraryManagementSystemAPI.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystemAPI.Models
{
    [Table("users")]
    public class UserModel:ModelBase
    {
        [StringLength(100)]
        public string? FirstName { get; set; }
        [StringLength(100)]
        public string? LastName { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(100)]
        public string? Mobile { get; set; }
        [StringLength(255)]
        public string? Password { get; set; }
        public bool Blocked { get; set; } = false;
        public bool Active { get; set; } = true;
        public float Fine { get; set; } = 0;
        public UserType UserType { get; set; }
    }
}
