using Microsoft.EntityFrameworkCore;
using SchoolProject.Api.Data;
using SchoolProject.Api.Mapping;

namespace SchoolProject.Api.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoriesTeachersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/categories/teachers");

        //GET /categories/teachers
        group.MapGet("/", async(SchoolProjectContext dbContext) => 
                    await dbContext.CategoryTeachers
                                   .Select(category => category.ToCategoryDto<CategoryTeacher>())
                                   .ToListAsync());
        return group;
    }

    public static RouteGroupBuilder MapCategoriesStudentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/categories/students");

        //GET /categories/students
        group.MapGet("/", async(SchoolProjectContext dbContext) => 
                    await dbContext.CategoryStudents
                                   .Select(category => category.ToCategoryDto<CategoryStudent>())
                                   .ToListAsync());
        return group;
    }
}
