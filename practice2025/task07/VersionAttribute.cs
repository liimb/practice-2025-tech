namespace task07;

[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute(int major, int minor) : Attribute
{
    public int Major => major;
    public int Minor => minor;
}
