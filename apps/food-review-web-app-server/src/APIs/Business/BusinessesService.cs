using FoodReviewWebApp.Infrastructure;

namespace FoodReviewWebApp.APIs;

public class BusinessesService : BusinessesServiceBase
{
    public BusinessesService(FoodReviewWebAppDbContext context)
        : base(context) { }
}
