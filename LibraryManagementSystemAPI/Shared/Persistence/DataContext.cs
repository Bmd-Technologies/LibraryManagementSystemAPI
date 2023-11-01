using LibraryManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Shared.Persistence
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<BookCategoryModel> BookCategories { get; set; }
        public virtual DbSet<BookModel> Books { get; set; }
        public virtual DbSet<OrderModel> Orders { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<UserModel>(entity =>
        //    {
        //        entity.HasKey(e => e.Id).HasName("PK_tbl_Users");
        //        entity.Property(e => e.FirstName).HasColumnType("varchar(100)").HasMaxLength(100);
        //        entity.Property(e => e.LastName).HasColumnType("varchar(100)").HasMaxLength(100);
        //        entity.Property(e => e.Email).HasColumnType("varchar(100)").HasMaxLength(100);
        //        entity.Property(e => e.Mobile).HasColumnType("varchar(30)").HasMaxLength(30);
        //        entity.Property(e => e.Password).HasColumnType("varchar(255)").HasMaxLength(255);
        //        entity.Property(e => e.Blocked).HasDefaultValue(false);
        //        entity.Property(e => e.Active).HasDefaultValue(true);
        //        entity.Property(e => e.Fine).HasColumnType("decimal(18, 3)").HasDefaultValue(0);
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        //    });


        //    OnModelCreatingPartial(modelBuilder);


        //}





    }
}
