using FoodReviewWebApp.APIs;
using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.APIs.Dtos;
using FoodReviewWebApp.APIs.Errors;
using FoodReviewWebApp.APIs.Extensions;
using FoodReviewWebApp.Infrastructure;
using FoodReviewWebApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodReviewWebApp.APIs;

public abstract class BusinessesServiceBase : IBusinessesService
{
    protected readonly FoodReviewWebAppDbContext _context;

    public BusinessesServiceBase(FoodReviewWebAppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Business
    /// </summary>
    public async Task<Business> CreateBusiness(BusinessCreateInput createDto)
    {
        var business = new BusinessDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            business.Id = createDto.Id;
        }

        _context.Businesses.Add(business);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BusinessDbModel>(business.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Business
    /// </summary>
    public async Task DeleteBusiness(BusinessWhereUniqueInput uniqueId)
    {
        var business = await _context.Businesses.FindAsync(uniqueId.Id);
        if (business == null)
        {
            throw new NotFoundException();
        }

        _context.Businesses.Remove(business);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Businesses
    /// </summary>
    public async Task<List<Business>> Businesses(BusinessFindManyArgs findManyArgs)
    {
        var businesses = await _context
            .Businesses.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return businesses.ConvertAll(business => business.ToDto());
    }

    /// <summary>
    /// Meta data about Business records
    /// </summary>
    public async Task<MetadataDto> BusinessesMeta(BusinessFindManyArgs findManyArgs)
    {
        var count = await _context.Businesses.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Business
    /// </summary>
    public async Task<Business> Business(BusinessWhereUniqueInput uniqueId)
    {
        var businesses = await this.Businesses(
            new BusinessFindManyArgs { Where = new BusinessWhereInput { Id = uniqueId.Id } }
        );
        var business = businesses.FirstOrDefault();
        if (business == null)
        {
            throw new NotFoundException();
        }

        return business;
    }

    /// <summary>
    /// Update one Business
    /// </summary>
    public async Task UpdateBusiness(
        BusinessWhereUniqueInput uniqueId,
        BusinessUpdateInput updateDto
    )
    {
        var business = updateDto.ToModel(uniqueId);

        _context.Entry(business).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Businesses.Any(e => e.Id == business.Id))
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
