using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.Infrastructure.Models;

namespace FoodReviewWebApp.APIs.Extensions;

public static class FoodMenusExtensions
{
    public static FoodMenu ToDto(this FoodMenuDbModel model)
    {
        return new FoodMenu
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FoodMenuDbModel ToModel(
        this FoodMenuUpdateInput updateDto,
        FoodMenuWhereUniqueInput uniqueId
    )
    {
        var foodMenu = new FoodMenuDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            foodMenu.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            foodMenu.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return foodMenu;
    }
}
