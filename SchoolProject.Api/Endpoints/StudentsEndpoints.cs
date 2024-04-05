using Microsoft.EntityFrameworkCore;
using SchoolProject.Api.Data;
using SchoolProject.Api.Dtos.StudentsDtos;
using SchoolProject.Api.Entitiies.StudetnsEntities;
using SchoolProject.Api.Mapping;

namespace SchoolProject.Api.Endpoints;

public static class StudentsEndpoints
{

    const string GetStudentEndpointsName = "GetStudents";
    public static RouteGroupBuilder MapStudentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("students")
                        .WithParameterValidation();
        //GET /students
        group.MapGet("/", async (SchoolProjectContext dbContext) =>
            await dbContext.Students
                           .Include(student => student.Category)
                           .Select(student => student.ToStudentSummaryDto())
                           .AsNoTracking()
                           .ToListAsync());

        //GET /students/{id}
        group.MapGet("/{id}", async(int id, SchoolProjectContext dbContext) =>
        {
            Student? student = await dbContext.Students.FindAsync(id);

            return student is null ?
                        Results.NotFound() : Results.Ok(student.ToStudentDetailsDto());
            
        }).WithName(GetStudentEndpointsName);

        //POST /students
        group.MapPost("/", async (CreateStudentDto newStudent, SchoolProjectContext dbContext) => 
        {
            Student student = newStudent.ToEntity();

            dbContext.Students.Add(student);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetStudentEndpointsName,
                                          new { id = student.Id },
                                          student.ToStudentDetailsDto());
        });

        //PUT /students/{id}
        group.MapPut("/{id}", async(int id, UpdateStudentDto updateStudent, SchoolProjectContext dbContext) =>
        {
            var existingStudent = await dbContext.Students.FindAsync(id);

            if(existingStudent is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingStudent)
                     .CurrentValues
                     .SetValues(updateStudent.ToEntity(id));
            
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /students/{id}
        group.MapDelete("/{id}", async (int id, SchoolProjectContext dbContext) => 
        {
            await dbContext.Students
                           .Where(student => student.Id == id)
                           .ExecuteDeleteAsync();

            return Results.NoContent();
        });
        return group;
    }
}