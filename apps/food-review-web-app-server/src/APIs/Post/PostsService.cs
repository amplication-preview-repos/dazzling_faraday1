using FoodReviewWebApp.Infrastructure;

namespace FoodReviewWebApp.APIs;

public class PostsService : PostsServiceBase
{
    public PostsService(FoodReviewWebAppDbContext context)
        : base(context) { }
}
