using System.Reflection;

namespace task10;

public static class LibrariesLoader
{
    public static void Load(string pathToDirectory)
    {
        var dllPaths = Directory.GetFiles(pathToDirectory, "*.dll");
        var dlls = dllPaths
            .Select(Assembly.LoadFrom)
            .ToArray();
        
        var dllCount = dlls.Length;
        var dllIndices = Enumerable.Range(0, dllCount).ToArray();
        var graph = new int[dllCount, dllCount];
        
        dllIndices.ToList().ForEach(i =>
        {
            var refs = dlls[i].GetReferencedAssemblies();

            dllIndices
                .Where(j => refs.Any(r => r.Name == dlls[j].GetName().Name))
                .ToList()
                .ForEach(j => graph[i, j] = 1);
        });
        
        var visited = new bool[dllCount];
        var resultList = new List<int>();
        
        Enumerable.Range(0, dllCount)
            .Where(i => !visited[i])
            .ToList()
            .ForEach(i => Sort(i, graph, visited, resultList));
        
        var sortedDlls = resultList.Select(i => dlls[i]).ToList();
        
        sortedDlls.ForEach(d =>
        {
            var commandType = d
                .GetTypes()
                .ToList()
                .FirstOrDefault(t => typeof(ICommand).IsAssignableFrom(t));
            
            var command = Activator.CreateInstance(commandType) as ICommand;
            
            command.Execute();
        });
    }
    
    private static void Sort(int v, int[,] graph, bool[] visited, List<int> result)
    {
        if (visited[v])
            return;
        
        int count = graph.GetLength(0);
        for (int j = 0; j < count; j++)
        {
            if (graph[v, j] == 1)
            {
                Sort(j, graph, visited, result);
            }
        }

        visited[v] = true;
        result.Add(v);
    }
}
