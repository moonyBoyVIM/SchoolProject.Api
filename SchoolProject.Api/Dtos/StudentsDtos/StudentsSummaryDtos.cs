using System.Security.Cryptography.X509Certificates;

namespace SchoolProject.Api.Dtos.StudentsDtos;

public record class StudentsSummaryDtos(
    int Id, 
    string Name,
    int Age,
    string Category
);

