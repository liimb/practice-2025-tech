using System.Text.Json;

namespace task13;

public static class StudentJsonService
{
    public static Student? GetStudentFromJson(this string json, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<Student>(json, options);
    }

    public static string ToJsonAndFile(this Student student)
    {
        var json = JsonSerializer.Serialize(student);
        File.WriteAllText("student.json", json);
        return json;
    }
}
