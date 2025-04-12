namespace DmmProject;
using System.Collections.Generic;

public static class FordFulkersonAlgorithm
{
    private static bool BFS(int[,] residualGraph, int source, int sink, int[] parent)
    {
        bool[] visited = new bool[residualGraph.GetLength(0)];
        
        
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(source);
        visited[source] = true;
        parent[source] = -1;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            for (int v = 0; v < residualGraph.GetLength(1); v++)
            {
                if (!visited[v] && residualGraph[u, v] > 0)
                {
                    queue.Enqueue(v);
                    visited[v] = true;
                    parent[v] = u;
                    if (v == sink) return true;
                }
            }
        }
        return false;
    }

    public static (int maxFlow, int[,] residual) FindMaxFlow(Graph graph, int source, int sink)
    {
        int[,] residualGraph = (int[,])graph.AdjMatrix.Clone();
        int[] parent = new int[graph.Vertices];
        int maxFlow = 0;

        while (BFS(residualGraph, source, sink, parent))
        {
            int pathFlow = int.MaxValue;
            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                
                pathFlow = Math.Min(pathFlow, residualGraph[u, v]);
            }

            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                residualGraph[u, v] -= pathFlow;
                residualGraph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
            Array.Fill(parent, -1);
        }
        return (maxFlow, residualGraph);
    }
}