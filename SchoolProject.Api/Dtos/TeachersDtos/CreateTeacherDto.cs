using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Api.Dtos.TeachersDtos;

public record class CreateTeacherDto(
    [Required][StringLength(100)] string Name,
    [Required][Range(25, 100)] int Age,
    [Required] int CategoryId
);

