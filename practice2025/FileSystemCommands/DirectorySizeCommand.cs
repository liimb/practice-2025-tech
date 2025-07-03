using CommandLib;

namespace FileSystemCommands;

public class DirectorySizeCommand(string path) : ICommand
{
    private readonly string _path = path;
    public void Execute()
    {
        
    }
}
