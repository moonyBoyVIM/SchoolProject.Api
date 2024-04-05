namespace SchoolProject.Api.Entitiies.StudetnsEntities;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public int CategoryId { get; set; }
    public CategoryStudent? Category { get; set; }
}