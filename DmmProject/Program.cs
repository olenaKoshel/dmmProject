namespace DmmProject;
using System.Diagnostics;
public class Program
{
    public static void Main()
    {
        const int n = 5;  
        const double density = 0.4;
        const int source = 0;
        const int sink = 4;

        var graph = GraphGenerator.GenerateRandomGraph(n, density);
            
        MatrixPrinter.PrintMatrix(graph.AdjMatrix);
        MatrixPrinter.PrintAdjacencyList(graph.AdjList);
        Console.WriteLine();

        var stopwatch = Stopwatch.StartNew();
        var result = FordFulkersonAlgorithm.FindMaxFlow(graph, source, sink);
        stopwatch.Stop();
        
        Console.WriteLine($"Максимальний потік: {result.maxFlow}");
        Console.WriteLine($"Час виконання: {stopwatch.ElapsedMilliseconds}мс");
    }
}