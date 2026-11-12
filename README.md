dotnet add package Javier.StudentGrades.StreamArchiver

using Javier.StudentGrades.StreamArchiver;

var transcript = new Transcript(new Student("4", "Kurt Wayboeeee"),
    new[]
    {
        new CourseGrade("IT506", "Object-Oriented Programming", 3, 4.0),
        new CourseGrade("IT106", "Computer Programming 1", 4, 3.0)
    });
var archiver = new TranscriptArchiver();

using (var fs = new FileStream("transcript.bin", FileMode.Create))
    archiver.Archive(transcript, fs);

using var fs2 = new FileStream("transcript.bin", FileMode.Open);
var restored = archiver.Restore(fs2);

Console.WriteLine($"{restored.Student.Name}, GPA {GpaCalculator.CalculateGpa(restored.Grades):F2}");}

The output should be: Kurt Wayboeeee, GPA 3.5 
