using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
