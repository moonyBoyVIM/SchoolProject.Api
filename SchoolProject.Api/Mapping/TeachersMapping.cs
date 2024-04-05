using SchoolProject.Api.Dtos.TeachersDtos;
using SchoolProject.Api.Entitiies.Teachers;

namespace SchoolProject.Api.Mapping;

public static class TeachersMapping
{
    public static Teacher ToEntity(this CreateTeacherDto newTeacher) => new Teacher()
    {
        Name = newTeacher.Name,
        Age = newTeacher.Age,
        CategoryId = newTeacher.CategoryId
    };

    public static Teacher ToEntity(this UpdateTeacherDto updateTeacher, int id) => new Teacher()
    {
        Id = id,
        Name = updateTeacher.Name,
        Age = updateTeacher.Age,
        CategoryId = updateTeacher.CategoryId
    };

    public static TeacherDetailsDto ToTeacherDetailsDto(this Teacher teacher) => 
        new(teacher.Id,
            teacher.Name,
            teacher.Age,
            teacher.CategoryId);

    public static TeachersSummaryDto ToTeacherSummaryDto(this Teacher teacher) => 
        new(teacher.Id,
            teacher.Name,
            teacher.Age,
            teacher.Category!.Name);
}
