using SchoolProject.Api.Dtos.StudentsDtos;
using SchoolProject.Api.Entitiies.StudetnsEntities;

namespace SchoolProject.Api.Mapping;

public static class StudentsMapping
{
    public static Student ToEntity(this CreateStudentDto newStudent) => new Student()
    {
        Name = newStudent.Name,
        Age = newStudent.Age,
        CategoryId = newStudent.CategoryId
    };

    public static Student ToEntity(this UpdateStudentDto updateStudent, int id) => new Student()
    {
        Id = id,
        Name = updateStudent.Name,
        Age = updateStudent.Age,
        CategoryId = updateStudent.CategoryId
    };

    public static StudentDetailsDto ToStudentDetailsDto(this Student student) => 
        new(student.Id,
            student.Name,
            student.Age,
            student.CategoryId);

    public static StudentsSummaryDtos ToStudentSummaryDto(this Student student) => 
        new(student.Id,
            student.Name,
            student.Age,
            student.Category!.Name);
}
