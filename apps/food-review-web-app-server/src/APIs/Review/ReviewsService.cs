using FoodReviewWebApp.Infrastructure;

namespace FoodReviewWebApp.APIs;

public class ReviewsService : ReviewsServiceBase
{
    public ReviewsService(FoodReviewWebAppDbContext context)
        : base(context) { }
}
