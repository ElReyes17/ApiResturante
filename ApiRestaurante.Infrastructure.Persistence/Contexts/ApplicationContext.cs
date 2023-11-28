
using ApiRestaurante.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<DishCategory> DishCategory { get; set; }

        public DbSet<Dishes> Dishes { get; set; }
       
        public DbSet<DishIngredients> DishIngredients { get; set; }

        public DbSet<Ingredients> Ingredients { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderState> OrderState { get; set; }

        public DbSet<Tables> Tables { get; set; }

        public DbSet<TableState> TableState { get; set; }

        public DbSet<DishOrders> DishOrders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            //Table Creations
            #region table
            modelBuilder.Entity<Dishes>().ToTable("Dishes");
            modelBuilder.Entity<DishCategory>().ToTable("DishCategory");
            modelBuilder.Entity<DishIngredients>().ToTable("DishIngredients");
            modelBuilder.Entity<Ingredients>().ToTable("Ingredients");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<DishOrders>().ToTable("DishOrders");
            modelBuilder.Entity<OrderState>().ToTable("OrderState");
            modelBuilder.Entity<Tables>().ToTable("Tables");
            modelBuilder.Entity<TableState>().ToTable("TableState");
            #endregion

            //Configuration primary keys
            #region keys
            modelBuilder.Entity<Dishes>().HasKey(a => a.Id);
            modelBuilder.Entity<DishCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<DishIngredients>().HasKey(a => new {a.DishId, a.IngredientsId});
            modelBuilder.Entity<Ingredients>().HasKey(a => a.Id);
            modelBuilder.Entity<Orders>().HasKey(a => a.Id);
            modelBuilder.Entity<DishOrders>().HasKey(a => new {a.DishesId, a.OrdersId});
            modelBuilder.Entity<OrderState>().HasKey(a => a.Id);
            modelBuilder.Entity<Tables>().HasKey(a => a.Id);
            modelBuilder.Entity<TableState>().HasKey(a => a.Id);
            #endregion

            //Relationships
            #region relationships
           
            modelBuilder.Entity<Dishes>()
                .HasOne(a => a.DishCategory)
                .WithMany(a => a.Dishes)
                .HasForeignKey(a => a.DishCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orders>()
                .HasOne(a => a.Tables)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.TableId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orders>()
                .HasOne(a => a.OrderState)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tables>()
                .HasOne(a => a.TableState)
                .WithMany(a => a.Tables)
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishOrders>()
                .HasOne(a => a.Dishes)
                .WithMany(a => a.DishOrders)
                .HasForeignKey(a => a.DishesId) 
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<DishOrders>()
                .HasOne(a => a.Orders)
                .WithMany(a => a.DishOrders)
                .HasForeignKey(a => a.OrdersId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<DishIngredients>()
                .HasOne(a => a.Ingredients)
                .WithMany(a => a.DishIngredients)
                .HasForeignKey(a => a.IngredientsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishIngredients>()
               .HasOne(a => a.Dishes)
               .WithMany(a => a.DishIngredients)
               .HasForeignKey(a => a.DishId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }

    }
}
