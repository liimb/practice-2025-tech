namespace task02;

public class Student(string name, string faculty, List<int> grades)
{
    public string Name { get; } = name;
    public string Faculty { get; } = faculty;
    public List<int> Grades { get; } = grades;
}
