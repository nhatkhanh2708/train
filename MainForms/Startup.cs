using Application.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MainForms
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLQuanCafe;Integrated Security=True;"));

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IDrinkService, DrinkService>();

            services.AddScoped<IDrinkCategoryRepository, DrinkCategoryRepository>();
            services.AddScoped<IDrinkCategoryService, DrinkCategoryService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBillService, BillService>();

            services.AddScoped<IBillDetailRepository, BillDetailRepository>();
            services.AddScoped<IBillDetailService, BillDetailService>();

            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStaffService, StaffService>();

            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IPromotionService, PromotionService>();

            services.AddScoped<IPromotionDetailRepository, PromotionDetailRepository>();
            services.AddScoped<IPromotionDetailService, PromotionDetailService>();

            services.AddScoped<ISignInManager, SignInManager>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
