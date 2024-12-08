using FoodReviewWebApp.Infrastructure;

namespace FoodReviewWebApp.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(FoodReviewWebAppDbContext context)
        : base(context) { }
}
