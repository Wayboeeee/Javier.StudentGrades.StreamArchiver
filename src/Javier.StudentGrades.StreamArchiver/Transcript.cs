namespace Javier.StudentGrades.StreamArchiver;

public sealed class Transcript
{
    private readonly List<CourseGrade> _grades;

    public Transcript(Student student, IEnumerable<CourseGrade>? grades = null)
    {
        Student = student;
        _grades = grades is null ? new() : new(grades);
    }

    public Student Student { get; }
    public IReadOnlyList<CourseGrade> Grades => _grades;

    public void AddGrade(CourseGrade grade) => _grades.Add(grade);
}