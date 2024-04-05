namespace SchoolProject.Api.Entitiies.Teachers;

public class Teacher
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public int CategoryId { get; set; }
    public CategoryTeacher? Category { get; set; }
}