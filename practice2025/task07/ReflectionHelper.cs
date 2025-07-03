using System.Reflection;
using System.Text;

namespace task07;

public static class ReflectionHelper
{
    public static string PrintTypeInfo(Type type)
    {
        StringBuilder info = new StringBuilder();
        
        var nameAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
        var versionAttribute = type.GetCustomAttribute<VersionAttribute>();

        info.Append($"Имя класса: {nameAttribute?.DisplayName}\n");
        info.Append($"Версия класса: {versionAttribute?.Major}.{versionAttribute?.Minor}\n");
        
        info.Append("Методы класса:\n");
        type.GetMethods()
            .Select(m => m.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName)
            .Where(name => name != null)
            .ToList()
            .ForEach(name => info.Append($"{name}\n"));

        info.Append("Свойства класса:\n");
        type.GetProperties()
            .Select(p => p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName)
            .Where(name => name != null)
            .ToList()
            .ForEach(name => info.Append($"{name}\n"));
        
        Console.Write(info.ToString());
        
        return info.ToString();
    }
}
