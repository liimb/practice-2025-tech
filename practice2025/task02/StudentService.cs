namespace task02;

public class StudentService(List<Student> students)
{
    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
        =>  students.Where(s => s.Faculty == faculty);

    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade) 
        => students.Where(s => s.Grades.Average() >= minAverageGrade);

    public IEnumerable<Student> GetStudentsOrderedByName()
        => students.OrderBy(s => s.Name);

    public ILookup<string, Student> GroupStudentsByFaculty()
        => students.ToLookup(s => s.Faculty);

    public string GetFacultyWithHighestAverageGrade()
        => students
            .GroupBy(s => s.Faculty)
            .Select(g => new
            {
                Faculty = g.Key, 
                Average = g.SelectMany(s => s.Grades).Average()
            })
            .OrderByDescending(g => g.Average)
            .First().Faculty;
}
