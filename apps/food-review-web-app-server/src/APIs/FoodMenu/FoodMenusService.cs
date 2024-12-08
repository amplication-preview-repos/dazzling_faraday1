using FoodReviewWebApp.Infrastructure;

namespace FoodReviewWebApp.APIs;

public class FoodMenusService : FoodMenusServiceBase
{
    public FoodMenusService(FoodReviewWebAppDbContext context)
        : base(context) { }
}
