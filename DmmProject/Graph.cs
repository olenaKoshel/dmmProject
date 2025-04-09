namespace DmmProject;
using System.Collections.Generic;

public class Graph
{
    public int Vertices { get; }
    public bool IsDirected { get; }
    public int[,] AdjMatrix { get; private set; }
    public Dictionary<int, List<Tuple<int, int>>> AdjList { get; private set; }

    public Graph(int vertices, bool isDirected = true)
    {
        Vertices = vertices;
        IsDirected = isDirected;
        AdjMatrix = new int[vertices, vertices];
        AdjList = new Dictionary<int, List<Tuple<int, int>>>();
        for (int i = 0; i < vertices; i++)
            AdjList[i] = new List<Tuple<int, int>>();
    }

    public void AddEdge(int u, int v, int capacity)
    {
        if (u == v) return;

        AdjMatrix[u, v] = capacity;
        AdjList[u].Add(Tuple.Create(v, capacity));

        if (!IsDirected)
        {
            AdjMatrix[v, u] = capacity;
            AdjList[v].Add(Tuple.Create(u, capacity));
        }
    }

    public void MatrixToList()
    {
        AdjList.Clear();
        for (int i = 0; i < Vertices; i++)
        {
            AdjList[i] = new List<Tuple<int, int>>();
            for (int j = 0; j < Vertices; j++)
            {
                if (AdjMatrix[i, j] > 0)
                    AdjList[i].Add(Tuple.Create(j, AdjMatrix[i, j]));
            }
        }
    }

    public void ListToMatrix()
    {
        AdjMatrix = new int[Vertices, Vertices];
        foreach (var u in AdjList.Keys)
        {
            foreach (var edge in AdjList[u])
                AdjMatrix[u, edge.Item1] = edge.Item2;
        }
    }
}