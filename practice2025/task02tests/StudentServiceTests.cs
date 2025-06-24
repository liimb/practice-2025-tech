using task02;

namespace task02tests;

public class StudentServiceTests
{
    private readonly StudentService _service;

    public StudentServiceTests()
    {
        List<Student> testStudents = [
            new("Иван", "ФИТ", [5, 4, 5]),
            new("Анна", "ФИТ", [3, 4, 3]),
            new("Петр", "Экономика", [5, 5, 5]),
            new("Яков", "Строительство", [2, 3, 2]),
            new("Максим", "Строительство", [])
        ];
        _service = new StudentService(testStudents);
    }

    [Fact]
    public void GetStudentsByFaculty_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsByFaculty("ФИТ").ToList();
        Assert.Equal(2, result.Count);
        Assert.True(result.All(s => s.Faculty == "ФИТ"));
    }
    
    [Fact]
    public void GetStudentsWithMinAverageGrade_ReturnsCorrectStudents()
    {
       var result = _service.GetStudentsWithMinAverageGrade(4).ToList();
       Assert.Equal(2, result.Count);
       Assert.True(result.All(s => s.Grades.Average() >= 4));
    }
    
    [Fact]
    public void GetStudentsOrderedByName_ReturnsSortedStudents()
    {
       var result = _service.GetStudentsOrderedByName().ToList();
       Assert.Equal("Анна", result[0].Name);
       Assert.Equal("Иван", result[1].Name);
       Assert.Equal("Максим", result[2].Name);
       Assert.Equal("Петр", result[3].Name);
       Assert.Equal("Яков", result[4].Name);
    }

    [Fact]
    public void GroupStudentsByFaculty_ReturnsGroupedStudents()
    {
       var result = _service.GroupStudentsByFaculty();

       Assert.Equal(3, result.Count);
       Assert.Equal(2, result["ФИТ"].Count());
       Assert.Single(result["Экономика"]);
       Assert.Equal(2, result["Строительство"].Count());
    }
    
    [Fact]
    public void GetFacultyWithHighestAverageGrade_ReturnsCorrectFaculty()
    {
        var result = _service.GetFacultyWithHighestAverageGrade();
        Assert.Equal("Экономика", result);
    }
}
