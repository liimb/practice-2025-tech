using System.Reflection;

namespace task05;

public class ClassAnalyzer(Type type)
{
    private Type _type = type;

    public IEnumerable<string> GetPublicMethods() =>
        _type.GetMethods().Select(m => m.Name).ToList();
    
    public IEnumerable<string> GetMethodParams(string methodName) =>
         _type.GetMethod(methodName).GetParameters().Select(m => m.Name).ToList();
    
    public IEnumerable<string> GetAllFields() => _type.GetRuntimeFields().Select(m => m.Name).ToList();

    public IEnumerable<string> GetProperties() => _type.GetProperties().Select(m => m.Name).ToList();

    public bool HasAttribute<T>() where T : Attribute => _type.IsDefined(typeof(T), inherit: true);
}
