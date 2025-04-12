namespace DmmProject;
using System.Collections.Generic;

public class Graph
{
    public int Vertices { get; }
    public bool IsDirected { get; }
    public int[,] AdjMatrix { get; set; }
    public Dictionary<int, List<(int to, int capacity)>> AdjList { get; }

    public Graph(int vertices, bool isDirected = true)
    {
        Vertices = vertices;
        IsDirected = isDirected;
        AdjMatrix = new int[vertices, vertices];
        AdjList = new Dictionary<int, List<(int, int)>>();
        for (int i = 0; i < vertices; i++) AdjList[i] = new List<(int, int)>();
    }

    public void AddEdge(int u, int v, int capacity)
    {
        if (u == v) return;

        AdjMatrix[u, v] = capacity;
        AdjList[u].Add((v, capacity));

        if (!IsDirected)
        {
            AdjMatrix[v, u] = capacity;
            AdjList[v].Add((u, capacity));
        }
    }
}