namespace DmmProject;
using System.Diagnostics;
public class Program
{
    public static void Main()
    {
        const int n = 200;  
        const double density = 0.9;
        const int source = 0;
        const int sink = 15;
        const int numExperiments = 100;

        long totalMilliseconds = 0;
        
        for (int i = 0; i < numExperiments; i++)
        {
            var graph = GraphGenerator.GenerateRandomGraph(n, density);
            
            /*MatrixPrinter.PrintMatrix(graph.AdjMatrix);
            MatrixPrinter.PrintAdjacencyList(graph.AdjList);
            Console.WriteLine();*/

            var stopwatch = Stopwatch.StartNew();
            var result = FordFulkersonAlgorithmList.FindMaxFlow_List(graph, source, sink);
            stopwatch.Stop();

            totalMilliseconds += stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Експеримент {i + 1}:");
            Console.WriteLine($"Максимальний потік: {result}");
            Console.WriteLine($"Час виконання: {stopwatch.ElapsedMilliseconds}мс");
            Console.WriteLine();
        }
        
        double averageMilliseconds = totalMilliseconds / (double)numExperiments;
        
        Console.WriteLine($"Середній час виконання за {numExperiments} експериментів: {averageMilliseconds} мс");
    }
}