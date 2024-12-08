using FoodReviewWebApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodReviewWebApp.Infrastructure;

public class FoodReviewWebAppDbContext : DbContext
{
    public FoodReviewWebAppDbContext(DbContextOptions<FoodReviewWebAppDbContext> options)
        : base(options) { }

    public DbSet<FoodMenuDbModel> FoodMenus { get; set; }

    public DbSet<BusinessDbModel> Businesses { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<ReviewDbModel> Reviews { get; set; }

    public DbSet<PostDbModel> Posts { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
