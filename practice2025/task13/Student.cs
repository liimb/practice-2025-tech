namespace task13;

public class Subject
{
    public string? Name {get; init; }
    public int Grade {get; init; }
    
    public override bool Equals(object? obj)
    {
        return obj is Subject other &&
               Name == other.Name &&
               Grade == other.Grade;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Grade);
    }
}

public class Student
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime BirthDate { get; init; }
    public List<Subject>? Grades { get; init; }
    
    public override bool Equals(object? obj)
    {
        return obj is Student other &&
               FirstName == other.FirstName &&
               LastName == other.LastName &&
               BirthDate == other.BirthDate &&
               Grades != null &&
               other.Grades != null &&
               Grades.SequenceEqual(other.Grades);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, BirthDate, Grades);
    }
}
