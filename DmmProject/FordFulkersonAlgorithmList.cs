using DmmProject;

public static class FordFulkersonAlgorithmList
{
    private static bool BFS(Dictionary<int, List<(int to, int capacity)>> residualGraph, int source, int sink, Dictionary<int, int> parent)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(source);
        visited.Add(source);
        parent[source] = -1;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();

            foreach (var (v, capacity) in residualGraph[u])
            {
                if (!visited.Contains(v) && capacity > 0)
                {
                    queue.Enqueue(v);
                    visited.Add(v);
                    parent[v] = u;
                    if (v == sink) return true;
                }
            }
        }
        return false;
    }

    public static int FindMaxFlow_List(Graph graph, int source, int sink)
    {
        var residualGraph = new Dictionary<int, List<(int to, int capacity)>>();

        foreach (var kvp in graph.AdjList)
        {
            residualGraph[kvp.Key] = new List<(int to, int capacity)>(kvp.Value);
        }

        int maxFlow = 0;
        Dictionary<int, int> parent = new Dictionary<int, int>();

        while (BFS(residualGraph, source, sink, parent))
        {
            int pathFlow = int.MaxValue;
            
            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                int capacity = residualGraph[u].Find(e => e.to == v).capacity;
                pathFlow = Math.Min(pathFlow, capacity);
            }
            
            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                
                var forwardEdge = residualGraph[u].FindIndex(e => e.to == v);
                residualGraph[u][forwardEdge] = (v, residualGraph[u][forwardEdge].capacity - pathFlow);
                
                if (!residualGraph.ContainsKey(v)) residualGraph[v] = new List<(int, int)>();
                var backIndex = residualGraph[v].FindIndex(e => e.to == u);
                if (backIndex != -1)
                {
                    residualGraph[v][backIndex] = (u, residualGraph[v][backIndex].capacity + pathFlow);
                }
                else
                {
                    residualGraph[v].Add((u, pathFlow));
                }
            }

            maxFlow += pathFlow;
            parent.Clear();
        }

        return maxFlow;
    }
}