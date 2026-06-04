public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // We call the getter from the base class to retrieve the private name
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}