namespace task10;

public static class LibrariesLoader
{
    public static void Load(string pathToDirectory)
    {
        var dllPaths = Directory.GetFiles(pathToDirectory, "*.dll");
        var dllCount = dllPaths.Length;
        var graph = new int[dllCount, dllCount];
        
        dllPaths.ToList().ForEach(d =>
        {
            
        });
    }
}
