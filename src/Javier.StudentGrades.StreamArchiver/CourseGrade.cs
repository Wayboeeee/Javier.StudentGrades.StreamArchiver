namespace Javier.StudentGrades.StreamArchiver;

public sealed class CourseGrade
{
    public CourseGrade(string courseCode, string title, int units, double gradePoint)
    {
        CourseCode = courseCode;
        Title = title;
        Units = units;
        GradePoint = gradePoint;
    }

    public string CourseCode { get; }
    public string Title { get; }
    public int Units { get; }
    public double GradePoint { get; }
}