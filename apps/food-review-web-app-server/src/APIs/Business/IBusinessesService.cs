using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;

namespace FoodReviewWebApp.APIs;

public interface IBusinessesService
{
    /// <summary>
    /// Create one Business
    /// </summary>
    public Task<Business> CreateBusiness(BusinessCreateInput business);

    /// <summary>
    /// Delete one Business
    /// </summary>
    public Task DeleteBusiness(BusinessWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Businesses
    /// </summary>
    public Task<List<Business>> Businesses(BusinessFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Business records
    /// </summary>
    public Task<MetadataDto> BusinessesMeta(BusinessFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Business
    /// </summary>
    public Task<Business> Business(BusinessWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Business
    /// </summary>
    public Task UpdateBusiness(BusinessWhereUniqueInput uniqueId, BusinessUpdateInput updateDto);
}
