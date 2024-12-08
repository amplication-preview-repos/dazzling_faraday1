using FoodReviewWebApp.Infrastructure;

namespace FoodReviewWebApp.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(FoodReviewWebAppDbContext context)
        : base(context) { }
}
