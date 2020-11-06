namespace DataAccess.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebModel : DbContext
    {
        public WebModel()
            : base("name=WebModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Email)
                .IsUnicode(false);
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductId);
            modelBuilder.Entity<Article>()
                .Property(e => e.Image)
                .IsUnicode(false);
            modelBuilder.Entity<Category>().Ignore(e => e.lsChild);
            modelBuilder.Entity<Product>().Ignore(e => e.CategoryName);
            modelBuilder.Entity<Product>().Ignore(e => e.Amount);
            modelBuilder.Entity<Account>().Ignore(e => e.ConfirmPassword);
        }
    }
}
