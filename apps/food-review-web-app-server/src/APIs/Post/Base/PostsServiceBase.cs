using FoodReviewWebApp.APIs;
using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.APIs.Errors;
using FoodReviewWebApp.APIs.Extensions;
using FoodReviewWebApp.Infrastructure;
using FoodReviewWebApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodReviewWebApp.APIs;

public abstract class PostsServiceBase : IPostsService
{
    protected readonly FoodReviewWebAppDbContext _context;

    public PostsServiceBase(FoodReviewWebAppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Post
    /// </summary>
    public async Task<Post> CreatePost(PostCreateInput createDto)
    {
        var post = new PostDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            post.Id = createDto.Id;
        }

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PostDbModel>(post.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Post
    /// </summary>
    public async Task DeletePost(PostWhereUniqueInput uniqueId)
    {
        var post = await _context.Posts.FindAsync(uniqueId.Id);
        if (post == null)
        {
            throw new NotFoundException();
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Posts
    /// </summary>
    public async Task<List<Post>> Posts(PostFindManyArgs findManyArgs)
    {
        var posts = await _context
            .Posts.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return posts.ConvertAll(post => post.ToDto());
    }

    /// <summary>
    /// Meta data about Post records
    /// </summary>
    public async Task<MetadataDto> PostsMeta(PostFindManyArgs findManyArgs)
    {
        var count = await _context.Posts.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Post
    /// </summary>
    public async Task<Post> Post(PostWhereUniqueInput uniqueId)
    {
        var posts = await this.Posts(
            new PostFindManyArgs { Where = new PostWhereInput { Id = uniqueId.Id } }
        );
        var post = posts.FirstOrDefault();
        if (post == null)
        {
            throw new NotFoundException();
        }

        return post;
    }

    /// <summary>
    /// Update one Post
    /// </summary>
    public async Task UpdatePost(PostWhereUniqueInput uniqueId, PostUpdateInput updateDto)
    {
        var post = updateDto.ToModel(uniqueId);

        _context.Entry(post).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Posts.Any(e => e.Id == post.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
