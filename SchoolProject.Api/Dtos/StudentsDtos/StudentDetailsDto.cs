using System.Security.Cryptography.X509Certificates;

namespace SchoolProject.Api.Dtos.StudentsDtos;

public record class StudentDetailsDto(
    int Id,
    string Name,
    int Age,
    int CategoryId
);

