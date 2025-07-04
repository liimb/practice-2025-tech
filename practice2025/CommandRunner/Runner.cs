using System.Reflection;
using CommandLib;
using FileSystemCommands;

namespace CommandRunner;

class Runner
{
    static void Main(string[] args)
    {
        var baseDir = AppContext.BaseDirectory;
        var dllPath = Path.Combine(baseDir, "FileSystemCommands.dll");
        
        var asm = Assembly.LoadFrom(dllPath);
        
        var testFilesDir = Path.Combine(Path.GetTempPath(), "TestDir2");
        Directory.CreateDirectory(testFilesDir);
                    
        var txtFile = Path.Combine(testFilesDir, "file1.txt");
        var logFile = Path.Combine(testFilesDir, "file2.log");
        File.WriteAllText(txtFile, "Text");
        File.WriteAllText(logFile, "Log");

        Type findFiles = asm
            .GetTypes()
            .ToList()
            .First(t => t.Name == "FindFilesCommand");

        if (Activator.CreateInstance(findFiles, testFilesDir, "*.txt") is FindFilesCommand filesCommand)
        {
            filesCommand.Execute();
            Console.WriteLine("Выполнение FindFilesCommand.Execute()");
        }
        
        var testDir = Path.Combine(Path.GetTempPath(), "dir");
        Directory.CreateDirectory(testDir);
        
        var file1 = Path.Combine(testDir, "file1.txt");
        var file2 = Path.Combine(testDir, "file2.txt");
        
        File.WriteAllText(file1, "Hello");
        File.WriteAllText(file2, "World!");
        
        Type sizeFiles = asm
            .GetTypes()
            .ToList()
            .First(t => t.Name == "DirectorySizeCommand");

        if (Activator.CreateInstance(sizeFiles, testDir) is DirectorySizeCommand sizeCommand)
        {
            sizeCommand.Execute();
            Console.WriteLine("Выполнение DirectorySizeCommand.Execute()");
        }
    }
}
