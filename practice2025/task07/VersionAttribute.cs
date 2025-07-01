namespace task07;

[AttributeUsage(AttributeTargets.All)]
public class VersionAttribute(string version) : Attribute
{
    public string Version => version;
}
