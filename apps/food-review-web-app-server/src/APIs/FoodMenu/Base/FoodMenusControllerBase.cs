using FoodReviewWebApp.APIs;
using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FoodMenusControllerBase : ControllerBase
{
    protected readonly IFoodMenusService _service;

    public FoodMenusControllerBase(IFoodMenusService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one FoodMenu
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<FoodMenu>> CreateFoodMenu(FoodMenuCreateInput input)
    {
        var foodMenu = await _service.CreateFoodMenu(input);

        return CreatedAtAction(nameof(FoodMenu), new { id = foodMenu.Id }, foodMenu);
    }

    /// <summary>
    /// Delete one FoodMenu
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFoodMenu([FromRoute()] FoodMenuWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteFoodMenu(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many FoodMenus
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<FoodMenu>>> FoodMenus(
        [FromQuery()] FoodMenuFindManyArgs filter
    )
    {
        return Ok(await _service.FoodMenus(filter));
    }

    /// <summary>
    /// Meta data about FoodMenu records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FoodMenusMeta(
        [FromQuery()] FoodMenuFindManyArgs filter
    )
    {
        return Ok(await _service.FoodMenusMeta(filter));
    }

    /// <summary>
    /// Get one FoodMenu
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<FoodMenu>> FoodMenu(
        [FromRoute()] FoodMenuWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.FoodMenu(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one FoodMenu
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFoodMenu(
        [FromRoute()] FoodMenuWhereUniqueInput uniqueId,
        [FromQuery()] FoodMenuUpdateInput foodMenuUpdateDto
    )
    {
        try
        {
            await _service.UpdateFoodMenu(uniqueId, foodMenuUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
