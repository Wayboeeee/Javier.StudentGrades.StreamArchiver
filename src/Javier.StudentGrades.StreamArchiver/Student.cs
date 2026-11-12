namespace Javier.StudentGrades.StreamArchiver;

public sealed class Student
{
    public Student(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; }
    public string Name { get; }
}