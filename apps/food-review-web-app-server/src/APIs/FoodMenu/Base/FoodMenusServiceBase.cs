using FoodReviewWebApp.APIs;
using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.APIs.Errors;
using FoodReviewWebApp.APIs.Extensions;
using FoodReviewWebApp.Infrastructure;
using FoodReviewWebApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodReviewWebApp.APIs;

public abstract class FoodMenusServiceBase : IFoodMenusService
{
    protected readonly FoodReviewWebAppDbContext _context;

    public FoodMenusServiceBase(FoodReviewWebAppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one FoodMenu
    /// </summary>
    public async Task<FoodMenu> CreateFoodMenu(FoodMenuCreateInput createDto)
    {
        var foodMenu = new FoodMenuDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            foodMenu.Id = createDto.Id;
        }

        _context.FoodMenus.Add(foodMenu);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FoodMenuDbModel>(foodMenu.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one FoodMenu
    /// </summary>
    public async Task DeleteFoodMenu(FoodMenuWhereUniqueInput uniqueId)
    {
        var foodMenu = await _context.FoodMenus.FindAsync(uniqueId.Id);
        if (foodMenu == null)
        {
            throw new NotFoundException();
        }

        _context.FoodMenus.Remove(foodMenu);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many FoodMenus
    /// </summary>
    public async Task<List<FoodMenu>> FoodMenus(FoodMenuFindManyArgs findManyArgs)
    {
        var foodMenus = await _context
            .FoodMenus.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return foodMenus.ConvertAll(foodMenu => foodMenu.ToDto());
    }

    /// <summary>
    /// Meta data about FoodMenu records
    /// </summary>
    public async Task<MetadataDto> FoodMenusMeta(FoodMenuFindManyArgs findManyArgs)
    {
        var count = await _context.FoodMenus.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one FoodMenu
    /// </summary>
    public async Task<FoodMenu> FoodMenu(FoodMenuWhereUniqueInput uniqueId)
    {
        var foodMenus = await this.FoodMenus(
            new FoodMenuFindManyArgs { Where = new FoodMenuWhereInput { Id = uniqueId.Id } }
        );
        var foodMenu = foodMenus.FirstOrDefault();
        if (foodMenu == null)
        {
            throw new NotFoundException();
        }

        return foodMenu;
    }

    /// <summary>
    /// Update one FoodMenu
    /// </summary>
    public async Task UpdateFoodMenu(
        FoodMenuWhereUniqueInput uniqueId,
        FoodMenuUpdateInput updateDto
    )
    {
        var foodMenu = updateDto.ToModel(uniqueId);

        _context.Entry(foodMenu).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.FoodMenus.Any(e => e.Id == foodMenu.Id))
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
