using CommandLib;

namespace FileSystemCommands;

public class FindFilesCommand(string path, string mask) : ICommand
{
    private readonly string _path = path;
    private readonly string _mask = mask;
    
    public void Execute()
    {
        
    }
}
