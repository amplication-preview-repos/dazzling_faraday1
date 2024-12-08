using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[ApiController()]
public class PostsController : PostsControllerBase
{
    public PostsController(IPostsService service)
        : base(service) { }
}
