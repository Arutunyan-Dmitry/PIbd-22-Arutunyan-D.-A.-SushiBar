using SushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace SushiBarDatabaseImplement
{
    public class SushiBarDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=ArutyunyanWin64\SQLEXPRESS;Initial Catalog=SushiBarDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Ingredient> Ingredients { set; get; }
        public virtual DbSet<Dish> Dishes { set; get; }
        public virtual DbSet<DishIngredient> DishIngredients { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<StorageFacility> StorageFacilities { set; get; }
        public virtual DbSet<StorageFacilityIngredient> StorageFacilityIngredients { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
    }
}
