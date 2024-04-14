using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantCRM.Domain.Entities;

namespace RestaurantCRM.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Restaurant> Restaurant { get; set; } = default!;
        public virtual DbSet<MenuItem> MenuItem { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Restaurant>(builder =>
            {
                builder.ToTable("Restaurant");
                builder
                .HasMany(restaurant => restaurant.MenuItems)
                .WithOne(menuitem => menuitem.Restaurant)
                .HasForeignKey(menuitem => menuitem.RestaurantId)
                .IsRequired();
            });

            builder.Entity<MenuItemInOrder>(builder =>
            {
                builder
                .HasOne(e => e.Order)
                .WithMany(a => a.ItemsOrdered)
                .HasForeignKey(e => e.OrderId);
            });

            //builder.Entity<MenuItem>(builder =>
            //{
            //    builder.ToTable("MenuItem");
            //    builder
            //    .HasOne(e => e.Restaurant)
            //    .WithMany(e => e.MenuItems)
            //    .HasForeignKey(e => e.RestaurantId)
            //    .IsRequired();
            //});

            //builder.Entity<Order>(builder =>
            //{
            //    builder.ToTable("Order");
            //    builder
            //    .HasMany(order => )
            //    .WithOne(order => order.Restaurant)
            //})
                
        }
        
    }
}
