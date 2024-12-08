using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[ApiController()]
public class BusinessesController : BusinessesControllerBase
{
    public BusinessesController(IBusinessesService service)
        : base(service) { }
}
