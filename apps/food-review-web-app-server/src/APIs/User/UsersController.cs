using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
