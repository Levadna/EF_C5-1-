using EF_C5_1_.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF_C5_1_
{
    public partial class MyShop : DbContext
    {
        public MyShop()
            : base("name=MyShop")
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Устанавливаем отношение "один ко многим" между заказами и продуктами
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("OrderProducts");
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("ProductId");
                });

            // Устанавливаем связь "один к одному" между заказами и клиентами
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientId);

        }
    }
}
