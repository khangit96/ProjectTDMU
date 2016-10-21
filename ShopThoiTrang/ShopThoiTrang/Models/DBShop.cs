namespace ShopThoiTrang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBShop : DbContext
    {
        public DBShop()
            : base("name=DBShop")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Checkout>Checkouts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.ProductCategories)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTtile)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.DecreasePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<Admin>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.password)
                .IsFixedLength();
        }
    }
}
