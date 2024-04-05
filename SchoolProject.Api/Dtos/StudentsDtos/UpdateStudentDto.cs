using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Api.Dtos.StudentsDtos;

public record class UpdateStudentDto(
    [Required][StringLength(100)] string Name,
    [Required][Range(6, 18)] int Age,
    [Required] int CategoryId
);

