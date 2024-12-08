using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.Infrastructure.Models;

namespace FoodReviewWebApp.APIs.Extensions;

public static class PostsExtensions
{
    public static Post ToDto(this PostDbModel model)
    {
        return new Post
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PostDbModel ToModel(this PostUpdateInput updateDto, PostWhereUniqueInput uniqueId)
    {
        var post = new PostDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            post.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            post.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return post;
    }
}
