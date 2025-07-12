using System.Text.Json;

namespace task13;

public static class StudentJsonService
{
    public static Student? GetStudentFromJson(this string json, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<Student>(json, options);
    }

    public static string ToJsonAndFile(this Student student, string path)
    {
        var json = JsonSerializer.Serialize(student);
        File.WriteAllText(path, json);
        return json;
    }
}
