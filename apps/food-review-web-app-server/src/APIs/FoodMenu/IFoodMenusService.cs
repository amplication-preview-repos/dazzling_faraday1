using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;

namespace FoodReviewWebApp.APIs;

public interface IFoodMenusService
{
    /// <summary>
    /// Create one FoodMenu
    /// </summary>
    public Task<FoodMenu> CreateFoodMenu(FoodMenuCreateInput foodmenu);

    /// <summary>
    /// Delete one FoodMenu
    /// </summary>
    public Task DeleteFoodMenu(FoodMenuWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many FoodMenus
    /// </summary>
    public Task<List<FoodMenu>> FoodMenus(FoodMenuFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about FoodMenu records
    /// </summary>
    public Task<MetadataDto> FoodMenusMeta(FoodMenuFindManyArgs findManyArgs);

    /// <summary>
    /// Get one FoodMenu
    /// </summary>
    public Task<FoodMenu> FoodMenu(FoodMenuWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one FoodMenu
    /// </summary>
    public Task UpdateFoodMenu(FoodMenuWhereUniqueInput uniqueId, FoodMenuUpdateInput updateDto);
}
