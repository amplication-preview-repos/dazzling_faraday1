using FoodReviewWebApp.APIs;
using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BusinessesControllerBase : ControllerBase
{
    protected readonly IBusinessesService _service;

    public BusinessesControllerBase(IBusinessesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Business
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Business>> CreateBusiness(BusinessCreateInput input)
    {
        var business = await _service.CreateBusiness(input);

        return CreatedAtAction(nameof(Business), new { id = business.Id }, business);
    }

    /// <summary>
    /// Delete one Business
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBusiness([FromRoute()] BusinessWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBusiness(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Businesses
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Business>>> Businesses(
        [FromQuery()] BusinessFindManyArgs filter
    )
    {
        return Ok(await _service.Businesses(filter));
    }

    /// <summary>
    /// Meta data about Business records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BusinessesMeta(
        [FromQuery()] BusinessFindManyArgs filter
    )
    {
        return Ok(await _service.BusinessesMeta(filter));
    }

    /// <summary>
    /// Get one Business
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Business>> Business(
        [FromRoute()] BusinessWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Business(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Business
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBusiness(
        [FromRoute()] BusinessWhereUniqueInput uniqueId,
        [FromQuery()] BusinessUpdateInput businessUpdateDto
    )
    {
        try
        {
            await _service.UpdateBusiness(uniqueId, businessUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
