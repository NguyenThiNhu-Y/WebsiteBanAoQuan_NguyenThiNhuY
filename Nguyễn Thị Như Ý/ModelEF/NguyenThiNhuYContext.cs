using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF
{
    public partial class NguyenThiNhuYContext : DbContext
    {
        public NguyenThiNhuYContext()
            : base("name=NguyenThiNhuYContext")
        {
        }

        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblUserAccount> tblUserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCategory>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .HasMany(e => e.tblProducts)
                .WithOptional(e => e.tblCategory)
                .HasForeignKey(e => e.idCategoryNo);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.idCategoryNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblUserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUserAccount>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUserAccount>()
                .Property(e => e.status)
                .IsUnicode(false);
        }
    }
}
