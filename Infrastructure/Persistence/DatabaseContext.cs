using Domain.Entities.BillAggregate;
using Domain.Entities.ManageAccount;
using Domain.Entities.Product;
using Domain.Entities.PromotionAggregate;
using Domain.Entities.StaffAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLQuanCafe;Integrated Security=True;");
        //}

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionDetail> PromotionDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
