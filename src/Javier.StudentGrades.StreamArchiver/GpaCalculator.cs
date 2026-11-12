namespace Javier.StudentGrades.StreamArchiver;

public static class GpaCalculator
{
    public static double CalculateGpa(IEnumerable<CourseGrade> grades)
    {
        double points = 0;
        int units = 0;

        foreach (var g in grades)
        {
            points += g.GradePoint * g.Units;
            units += g.Units;
        }

        return units == 0 ? 0 : points / units;
    }
}