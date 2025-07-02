namespace task07;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
public class DisplayNameAttribute(string name) : Attribute
{
    public string DisplayName => name;
}
