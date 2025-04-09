namespace DmmProject;
class Program
{
    public static void Main()
    {
        Graph graph = GraphGenerator.GenerateRandomGraph(4, 0.3);
        Console.WriteLine("Матриця суміжності (пропускні спроможності):");
        MatrixPrinter.PrintMatrix(graph.AdjMatrix);

        int source = 0;
        int sink = 3;
        var result = FordFulkersonAlgorithm.FindMaxFlow(graph, source, sink);

        Console.WriteLine("\nМаксимальний потік: " + result.maxFlow);
        Console.WriteLine("Залишкова матриця:");
        MatrixPrinter.PrintMatrix(result.residual);
    }
}