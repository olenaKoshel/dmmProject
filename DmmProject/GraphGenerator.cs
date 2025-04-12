namespace DmmProject;
public static class GraphGenerator
{
    public static Graph GenerateRandomGraph(int n, double density, int maxCapacity = 100, bool isDirected = true)
    {
        Graph graph = new Graph(n, isDirected);
        int maxPossibleEdges = n * (n - 1);
        int numEdges = (int)(density * maxPossibleEdges);
        Random rand = new Random();
        int edgesAdded = 0;

        while (edgesAdded < numEdges)
        {
            int u = rand.Next(n);
            int v = rand.Next(n);
            if (u != v && graph.AdjMatrix[u, v] == 0)
            {
                int capacity = rand.Next(1, maxCapacity + 1);
                graph.AddEdge(u, v, capacity);
                edgesAdded++;
            }
        }
        return graph;
    }
}