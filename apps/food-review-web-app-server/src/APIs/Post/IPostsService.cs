using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;

namespace FoodReviewWebApp.APIs;

public interface IPostsService
{
    /// <summary>
    /// Create one Post
    /// </summary>
    public Task<Post> CreatePost(PostCreateInput post);

    /// <summary>
    /// Delete one Post
    /// </summary>
    public Task DeletePost(PostWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Posts
    /// </summary>
    public Task<List<Post>> Posts(PostFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Post records
    /// </summary>
    public Task<MetadataDto> PostsMeta(PostFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Post
    /// </summary>
    public Task<Post> Post(PostWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Post
    /// </summary>
    public Task UpdatePost(PostWhereUniqueInput uniqueId, PostUpdateInput updateDto);
}
