using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.Infrastructure.Models;

namespace FoodReviewWebApp.APIs.Extensions;

public static class BusinessesExtensions
{
    public static Business ToDto(this BusinessDbModel model)
    {
        return new Business
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BusinessDbModel ToModel(
        this BusinessUpdateInput updateDto,
        BusinessWhereUniqueInput uniqueId
    )
    {
        var business = new BusinessDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            business.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            business.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return business;
    }
}
