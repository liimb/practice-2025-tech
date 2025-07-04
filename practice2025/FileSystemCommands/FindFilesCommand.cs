using CommandLib;

namespace FileSystemCommands;

public class FindFilesCommand(string path, string mask) : ICommand
{
    public List<string> FoundFiles { get; private set; } = [];

    public void Execute()
    {
        FoundFiles = Directory.GetFiles(path, mask, SearchOption.AllDirectories).ToList();
    }
}
