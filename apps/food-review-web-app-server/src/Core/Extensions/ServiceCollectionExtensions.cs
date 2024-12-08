using FoodReviewWebApp.APIs;

namespace FoodReviewWebApp;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBusinessesService, BusinessesService>();
        services.AddScoped<IFoodMenusService, FoodMenusService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<IReviewsService, ReviewsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
