using FoodReviewWebApp.APIs.Common;
using FoodReviewWebApp.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodReviewWebApp.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindManyArgs : FindManyInput<User, UserWhereInput> { }
