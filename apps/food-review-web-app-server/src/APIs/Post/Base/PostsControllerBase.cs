using FoodReviewWebApp.APIs;
using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PostsControllerBase : ControllerBase
{
    protected readonly IPostsService _service;

    public PostsControllerBase(IPostsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Post
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Post>> CreatePost(PostCreateInput input)
    {
        var post = await _service.CreatePost(input);

        return CreatedAtAction(nameof(Post), new { id = post.Id }, post);
    }

    /// <summary>
    /// Delete one Post
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePost([FromRoute()] PostWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePost(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Posts
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Post>>> Posts([FromQuery()] PostFindManyArgs filter)
    {
        return Ok(await _service.Posts(filter));
    }

    /// <summary>
    /// Meta data about Post records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PostsMeta([FromQuery()] PostFindManyArgs filter)
    {
        return Ok(await _service.PostsMeta(filter));
    }

    /// <summary>
    /// Get one Post
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Post>> Post([FromRoute()] PostWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Post(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Post
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePost(
        [FromRoute()] PostWhereUniqueInput uniqueId,
        [FromQuery()] PostUpdateInput postUpdateDto
    )
    {
        try
        {
            await _service.UpdatePost(uniqueId, postUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
