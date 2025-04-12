namespace DmmProject;

public static class MatrixPrinter
{
    public static void PrintMatrix(int[,] matrix, string title = "Матриця суміжності")
    {
        Console.WriteLine(title + ":");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i, j].ToString().PadLeft(4));
            Console.WriteLine();
        }
    }

    public static void PrintAdjacencyList(Dictionary<int, List<(int to, int capacity)>> adjList)
    {
        Console.WriteLine("\nСписки суміжності:");
        for (int i = 0; i < adjList.Count; i++)
        {
            Console.Write($"{i}: ");
            foreach (var edge in adjList[i]) Console.Write($"{edge.to}({edge.capacity}) ");
            Console.WriteLine();
        }
    }
}