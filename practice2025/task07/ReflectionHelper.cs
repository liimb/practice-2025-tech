using System.Reflection;

namespace task07;

public static class ReflectionHelper
{
    public static void PrintTypeInfo(Type type)
    {
        var nameAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
        var versionAttribute = type.GetCustomAttribute<VersionAttribute>();
        
        Console.WriteLine($"Имя класса: {nameAttribute?.DisplayName}");
        Console.WriteLine($"Версия класса: {versionAttribute?.Major}.{versionAttribute?.Minor}");
        
        Console.WriteLine("Методы класса:");
        type.GetMethods().ToList().ForEach(m => Console.WriteLine(m.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName));
        Console.WriteLine("Свойства класса:");
        type.GetProperties().ToList().ForEach(p => Console.WriteLine(p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName));
    }
}
