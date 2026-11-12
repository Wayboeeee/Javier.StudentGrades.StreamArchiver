using System.Text;

namespace Javier.StudentGrades.StreamArchiver;

public sealed class TranscriptArchiver : ITranscriptService
{
    public const ushort CurrentVersion = 1;
    private static readonly byte[] Magic = { (byte)'S', (byte)'G', (byte)'T', (byte)'A' };

    public void Archive(Transcript transcript, Stream destination)
    {
        using var w = new BinaryWriter(destination, Encoding.UTF8, leaveOpen: true);

        w.Write(Magic);            
        w.Write(CurrentVersion);   

        w.Write(transcript.Student.Id);
        w.Write(transcript.Student.Name);
        w.Write(transcript.Grades.Count);

        foreach (var g in transcript.Grades)
        {
            w.Write(g.CourseCode);
            w.Write(g.Title);
            w.Write(g.Units);
            w.Write(g.GradePoint);
        }
    }

    public Transcript Restore(Stream source)
    {
        using var r = new BinaryReader(source, Encoding.UTF8, leaveOpen: true);

        var magic = r.ReadBytes(4);
        if (!magic.SequenceEqual(Magic))
            throw new InvalidDataException("Not a transcript archive.");

        ushort version = r.ReadUInt16();
        if (version == 0 || version > CurrentVersion)
            throw new InvalidDataException(
                $"Unsupported archive version {version}. This build supports up to {CurrentVersion}.");

        var student = new Student(r.ReadString(), r.ReadString());
        int count = r.ReadInt32();

        var grades = new List<CourseGrade>();
        for (int i = 0; i < count; i++)
        {
            grades.Add(new CourseGrade(
                r.ReadString(), r.ReadString(), r.ReadInt32(), r.ReadDouble()));
        }

        return new Transcript(student, grades);
    }
}
