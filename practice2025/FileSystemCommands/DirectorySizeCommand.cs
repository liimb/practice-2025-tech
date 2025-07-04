using CommandLib;

namespace FileSystemCommands;

public class DirectorySizeCommand(string path) : ICommand
{
    public long Size { get; private set; }
    
    public void Execute()
    {
        Size = 0;
        Directory.GetFiles(path, "*", SearchOption.AllDirectories)
            .ToList()
            .ForEach(f => Size += new FileInfo(f).Length);
    }
}
