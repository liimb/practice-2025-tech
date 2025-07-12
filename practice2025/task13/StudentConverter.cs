namespace task13;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class StudentConverter : JsonConverter<Student>
{
    private const string DateFormat = "dd-MM-yyyy";

    public override Student Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;
        
        var birthDateStr = root.GetProperty("BirthDate").GetString();
        var birthDate = DateTime.ParseExact(birthDateStr!, DateFormat, null);

        if (birthDate > DateTime.Now) throw new JsonException("Неверная дата рождения");

        var gradesList = root.GetProperty("Grades")
            .EnumerateArray()
            .Select(e => new Subject
            {
                Name = e.GetProperty("Name").GetString(),
                Grade = e.GetProperty("Grade").GetInt32()
            })
            .ToList();

        if (gradesList.Any(g => g.Grade is < 2 or > 5))
            throw new JsonException("Неверная оценка");
        
        var firstName = root.GetProperty("FirstName").GetString();
        var lastName = root.GetProperty("LastName").GetString();

        return new Student
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate,
            Grades = gradesList
        };
    }

    public override void Write(Utf8JsonWriter writer, Student value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("FirstName", value.FirstName);
        writer.WriteString("LastName", value.LastName);
        writer.WriteString("BirthDate", value.BirthDate.ToString(DateFormat));

        writer.WritePropertyName("Grades");
        writer.WriteStartArray();
        
        if (value.Grades != null)
        {
            foreach (var subject in value.Grades)
            {
                writer.WriteStartObject();
                writer.WriteString("Name", subject.Name);
                writer.WriteNumber("Grade", subject.Grade);
                writer.WriteEndObject();
            }
        }

        writer.WriteEndArray();
        writer.WriteEndObject();
    }
}
