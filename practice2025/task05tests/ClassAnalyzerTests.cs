using System.ComponentModel;
using System.Runtime.CompilerServices;
using task05;

namespace task05tests;

public class TestClass
{
    public int PublicField;
    private string _privateField;
    public int Property { get; set; }

    public void Method() { }
    public void MethodTwo(string param2) { }
}

[Serializable]
public class AttributedClass { }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methods = analyzer.GetPublicMethods();

        Assert.Contains("Method", methods);
    }
    
    [Fact]
    public void GetMethodParams_ReturnsCorrectMethodParams()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methodParams = analyzer.GetMethodParams("MethodTwo");

        Assert.Contains("param2", methodParams);
        Assert.True(methodParams.Last() == "Void");
    }

    [Fact]
    public void GetAllFields_ReturnsIncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var fields = analyzer.GetAllFields();

        Assert.Contains("_privateField", fields);
    }
    
    [Fact]
    public void GetProperties_ReturnsIncludesProperties()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var properties = analyzer.GetProperties();

        Assert.Contains("Property", properties);
    }
    
    [Fact]
    public void HasAttribute_ReturnsHasAttribute()
    {
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));
        var hasSerializableAttribute = analyzer.HasAttribute<SerializableAttribute>();

        Assert.True(hasSerializableAttribute);
    }
    
    [Fact]
    public void HasAttribute_ReturnsHasNotAttribute()
    {
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));
        var hasNotAttribute = analyzer.HasAttribute<DisplayNameAttribute>();

        Assert.False(hasNotAttribute);
    }
}
