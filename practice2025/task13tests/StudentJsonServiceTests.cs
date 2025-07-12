using System.Text.Json;
using System.Text.Json.Serialization;
using task13;

namespace task13tests;

public class StudentJsonServiceTests
{
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new StudentConverter() }
    };
    
    private readonly Student _student = new()
    {
        FirstName = "Алексей",
        LastName = "Фамилия",
        BirthDate = DateTime.Parse("02-02-1999"),
        Grades =
        [
            new Subject { Name = "История", Grade = 5 },
            new Subject { Name = "Физика", Grade = 4 }
        ]
    };
    
    [Fact]
    public void StudentJsonServiceTest_SuccessSerialize()
    {
        var expected = "{\"FirstName\":\"\\u0410\\u043B\\u0435\\u043A\\u0441\\u0435\\u0439\",\"LastName\":\"\\u0424\\u0430\\u043C\\u0438\\u043B\\u0438\\u044F\",\"BirthDate\":\"1999-02-02T00:00:00\",\"Grades\":[{\"Name\":\"\\u0418\\u0441\\u0442\\u043E\\u0440\\u0438\\u044F\",\"Grade\":5},{\"Name\":\"\\u0424\\u0438\\u0437\\u0438\\u043A\\u0430\",\"Grade\":4}]}";
        var json = _student.ToJsonAndFile();
        var jsonFromFile = File.ReadAllText("student.json");
        
        Assert.Equal(expected, json);
        Assert.Equal(expected, jsonFromFile);
    }
    
    [Fact]
    public void StudentJsonServiceTest_SuccessDeserialize()
    {
        const string json = "{\"FirstName\":\"Алексей\",\"LastName\":\"Фамилия\",\"BirthDate\":\"02-02-1999\",\"Grades\":[{\"Name\":\"История\",\"Grade\":5},{\"Name\":\"Физика\",\"Grade\":4}]}";
        var student = json.GetStudentFromJson(_options);
        
        Assert.Equal(student, _student);
    }
    
    [Fact]
    public void StudentJsonServiceTest_HasDeserializeExceptionOnIncorrectGrades()
    {
        const string json = "{\"FirstName\":\"Алексей\",\"LastName\":\"Фамилия\",\"BirthDate\":\"02-02-1999\",\"Grades\":[{\"Name\":\"История\",\"Grade\":54},{\"Name\":\"Физика\",\"Grade\":4}]}";

        Assert.Throws<JsonException>(() => json.GetStudentFromJson(_options));
    }
    
    [Fact]
    public void StudentJsonServiceTest_HasDeserializeExceptionOnIncorrectDateTime()
    {
        const string json = "{\"FirstName\":\"Алексей\",\"LastName\":\"Фамилия\",\"BirthDate\":\"02-02-2222\",\"Grades\":[{\"Name\":\"История\",\"Grade\":5},{\"Name\":\"Физика\",\"Grade\":4}]}";

        Assert.Throws<JsonException>(() => json.GetStudentFromJson(_options));
    }
}
