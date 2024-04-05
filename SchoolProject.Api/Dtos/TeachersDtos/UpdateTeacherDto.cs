using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Api.Dtos.TeachersDtos;

public record class UpdateTeacherDto(
    [Required][StringLength(100)] string Name,
    [Required][Range(25, 100)] int Age,
    [Required] int CategoryId
);

