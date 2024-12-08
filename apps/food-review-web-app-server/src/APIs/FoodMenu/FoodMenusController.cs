using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[ApiController()]
public class FoodMenusController : FoodMenusControllerBase
{
    public FoodMenusController(IFoodMenusService service)
        : base(service) { }
}
