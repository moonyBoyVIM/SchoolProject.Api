using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Api.Data;
using SchoolProject.Api.Dtos.TeachersDtos;
using SchoolProject.Api.Entitiies.Teachers;
using SchoolProject.Api.Mapping;

namespace SchoolProject.Api;

public static class TeachersEndpoints
{
    const string GetTeachersEndpointsName = "GetTeachers";

    public static RouteGroupBuilder MapTeachersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("teachers")
                       .WithParameterValidation();

        //GET /teachers
        group.MapGet("/", async(SchoolProjectContext dbContext) =>
                await dbContext.Teachers
                               .Include(teacher => teacher.Category)
                               .Select(teacher => teacher.ToTeacherSummaryDto())
                               .AsNoTracking()
                               .ToListAsync());

        //GET /teahers/{id}
        group.MapGet("/{id}", async(int id, SchoolProjectContext dbContext) =>
        {
            Teacher? teacher = await dbContext.Teachers.FindAsync(id);

            return teacher is null ?
                    Results.NotFound() : Results.Ok(teacher.ToTeacherDetailsDto());
        }).WithName(GetTeachersEndpointsName);

        //POST /teachers
        group.MapPost("/", async (CreateTeacherDto newTeacher, SchoolProjectContext dbContext) => 
        {
            Teacher teacher = newTeacher.ToEntity();

            dbContext.Teachers.Add(teacher);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetTeachersEndpointsName,
                                          new{id = teacher.Id},
                                          teacher.ToTeacherDetailsDto());
        });

        //PUT /teachers/{id}
        group.MapPut("/{id}", async(UpdateTeacherDto updateTeacher, SchoolProjectContext dbContext, int id) =>
        {
            var existingTeacher = await dbContext.Teachers.FindAsync(id);

            if(existingTeacher is null)
            {
                return Results.NotFound();
            }

            dbContext.Teachers.Entry(existingTeacher)
                              .CurrentValues
                              .SetValues(updateTeacher.ToEntity(id));
            await dbContext.SaveChangesAsync();
            
            return Results.NoContent();
        });

        //DELETE /teacher/{id}
        group.MapDelete("/{id}", async(int id, SchoolProjectContext dbContext) => 
        {
            await dbContext.Teachers.Where(teacher => teacher.Id == id)
                                    .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}