using SchoolProject.Api.Dtos.CategoryDtos;
using SchoolProject.Api.Entitiies;

namespace SchoolProject.Api.Mapping;

public static class CategoryMapping
{
    public static CategoryDto ToCategoryDto<T>(this CategoryCommon category) =>
        new(category.Id,
            category.Name); 
}