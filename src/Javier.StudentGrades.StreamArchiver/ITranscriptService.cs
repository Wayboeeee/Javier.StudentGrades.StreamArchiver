namespace Javier.StudentGrades.StreamArchiver;

public interface ITranscriptService
{
    void Archive(Transcript transcript, Stream destination);
    Transcript Restore(Stream source);
}