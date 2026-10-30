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
        // can't use _studentName directly because it's private in Assignment
        string studentName = GetStudentName();
        return _title + " by " + studentName;
    }
}
