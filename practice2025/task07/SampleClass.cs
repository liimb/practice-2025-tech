namespace task07;

[Version(1, 0)]
[DisplayName("Пример класса")]
public class SampleClass
{
    [DisplayName("Тестовый метод")]
    public void TestMethod() {}
    
    [DisplayName("Числовое свойство")]
    public string Number { get; set; }
}
