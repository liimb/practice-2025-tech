using System.Diagnostics;
using FileSystemCommands;

namespace task08tests;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "dir");
        Directory.CreateDirectory(testDir);
        
        var file1 = Path.Combine(testDir, "file1.txt");
        var file2 = Path.Combine(testDir, "file2.txt");
        
        File.WriteAllText(file1, "Hello");
        File.WriteAllText(file2, "World!");

        var expectedSize = new FileInfo(file1).Length + new FileInfo(file2).Length;
        
        var command = new DirectorySizeCommand(testDir);
        command.Execute();
        
        Assert.Equal(expectedSize, command.Size);

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir2");
        Directory.CreateDirectory(testDir);
        
        var txtFile = Path.Combine(testDir, "file1.txt");
        var logFile = Path.Combine(testDir, "file2.log");

        File.WriteAllText(txtFile, "Text");
        File.WriteAllText(logFile, "Log");

        var command = new FindFilesCommand(testDir, "*.txt");
        command.Execute();
        
        Assert.Single(command.FoundFiles);
        Assert.Contains(txtFile, command.FoundFiles);

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void ConsoleCommandRunner_ShouldExpectedPrint()
    {
        var baseDir = AppContext.BaseDirectory;
        var exePath = Path.Combine(baseDir, "CommandRunner");
        
        string expected = "Выполнение FindFilesCommand.Execute()\nВыполнение DirectorySizeCommand.Execute()\n";
        
        var startInfo = new ProcessStartInfo
        {
            FileName = exePath,
            RedirectStandardOutput = true,
        };

        using var process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();
        
        Assert.Equal(expected, process.StandardOutput.ReadToEnd());
    }
}
