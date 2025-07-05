using System.Reflection;

namespace task09;

class DllAnalyzer
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Укажите путь к .dll");
            return;
        }
        
        string path = args[0];

        if (!File.Exists(path))
        {
            return;
        }
        
        var asm = Assembly.LoadFrom(path);

        asm.GetTypes()
            .ToList()
            .ForEach(t =>
            {
                Console.WriteLine($"Класс: {t.Name}");
                t.GetMethods().ToList().ForEach(m =>
                {
                    Console.WriteLine("Метод:");
                    Console.WriteLine(m.Name);
                    if (m.GetParameters().Length == 0) return;
                    Console.WriteLine("Параметры метода и их тип:");
                    m.GetParameters().ToList().ForEach(p =>
                    {
                        Console.WriteLine($"{p.Name} {p.ParameterType.Name}");
                    });
                });

                if (t.GetCustomAttributes().Any())
                {
                    Console.WriteLine("Атрибуты:");
                    t.GetCustomAttributes().ToList().ForEach(m => Console.WriteLine(m.GetType().Name));
                }

                if (t.GetConstructors().Length != 0)
                {
                    Console.WriteLine("Конструкторы:");
                    t.GetConstructors().ToList().ForEach(c =>
                    {
                        Console.WriteLine(c.Name);
                        if (c.GetParameters().Length == 0) return;
                        Console.WriteLine("Параметры конструктора и их тип:");
                        c.GetParameters().ToList().ForEach(p =>
                        {
                            Console.WriteLine($"{p.Name} {p.ParameterType.Name}");
                        });
                    });
                }

                Console.WriteLine();
            });
    }
}
