using System.Reflection;
using CommandLib;

namespace CommandRunner;

class Program
{
    static void Main(string[] args)
    {
        var baseDir = AppContext.BaseDirectory;
        var dllPath = Path.Combine(baseDir, "FileSystemCommands.dll");
        
        var asm = Assembly.LoadFrom(dllPath);
        
        asm.GetTypes()
            .ToList()
            .ForEach(t =>
            {
                object? instance = null;
                
                if (t.Name == "FindFilesCommand")
                {
                    var testDir = Path.Combine(Path.GetTempPath(), "TestDir2");
                    Directory.CreateDirectory(testDir);
                    
                    var txtFile = Path.Combine(testDir, "file1.txt");
                    var logFile = Path.Combine(testDir, "file2.log");
                    File.WriteAllText(txtFile, "Text");
                    File.WriteAllText(logFile, "Log");
                    
                    instance = Activator.CreateInstance(t, testDir, "*.txt");
                }
                else if (t.Name == "DirectorySizeCommand")
                {
                    var testDir = Path.Combine(Path.GetTempPath(), "dir");
                    Directory.CreateDirectory(testDir);
        
                    var file1 = Path.Combine(testDir, "file1.txt");
                    var file2 = Path.Combine(testDir, "file2.txt");
        
                    File.WriteAllText(file1, "Hello");
                    File.WriteAllText(file2, "World!");
                    
                    instance = Activator.CreateInstance(t, testDir);
                }
                
                if (instance is ICommand command)
                {
                    command.Execute();
                }
            });
    }
}
