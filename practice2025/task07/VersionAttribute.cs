namespace task07;

[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute(string version) : Attribute
{
    public string Version => version;
}
