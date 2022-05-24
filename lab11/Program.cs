using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            IGraph graph = new AdList();
            graph.AddDirectedEdge(0, 1, 1);
            graph.AddDirectedEdge(0, 2, 1);
            graph.AddDirectedEdge(3, 0, 1);
            graph.AddDirectedEdge(1, 3, 1);
            graph.AddUndirectedEdge(2, 3, 1);

            graph.LevelTraversal(0, n => Console.WriteLine(n));
        }

        record Edge
        {
            public int Node { get; set; }
            public double Weight { get; set; }
        }

        class AdList : IGraph
        {
            Dictionary<int, HashSet<Edge>> _edges = new Dictionary<int, HashSet<Edge>>();

            public bool AddDirectedEdge(int source, int destination, int weight)
            {
                if (!_edges.ContainsKey(source)) _edges.Add(source, new HashSet<Edge>());
                if (!_edges.ContainsKey(destination)) _edges.Add(destination, new HashSet<Edge>());

                _edges[source].Add(new Edge() { Node = destination, Weight = weight });
                return true;
            }

            public bool AddUndirectedEdge(int source, int destination, int weight)
            {
                return AddDirectedEdge(source, destination, weight) && AddDirectedEdge(destination, source, weight);
            }

            public void LevelTraversal(int source, Action<int> action)
            {
                Queue<int> q = new Queue<int>();
                ISet<int> visited = new HashSet<int>();
                q.Enqueue(source);
                while (q.Count > 0)
                {
                    int node = q.Dequeue();
                    if (visited.Contains(node)) continue;
                    action.Invoke(node);
                    visited.Add(node);
                    HashSet<Edge> children = _edges[node];

                    foreach (Edge edge in children)
                    {
                        q.Enqueue(edge.Node);
                    }
                }
            }
        }

        interface IGraph
        {
            bool AddDirectedEdge(int source, int destination, int weight);
            bool AddUndirectedEdge(int source, int destination, int weight);
            public void LevelTraversal(int source, Action<int> action);
        }

        class AdMatrix : IGraph
        {
            private int[,] _matrix;

            public AdMatrix(int size)
            {
                _matrix = new int[size, size];
            }

            public bool AddDirectedEdge(int source, int destination, int weight)
            {
                // kod sprawdzajacy source i destination
                _matrix[source, destination] = weight;
                return true;
            }

            public bool AddUndirectedEdge(int source, int destination, int weight)
            {
                return AddDirectedEdge(source, destination, weight) && AddDirectedEdge(destination, source, weight);
            }

            public void LevelTraversal(int source, Action<int> action)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                for (int row = 0; row < _matrix.GetLength(0); row++)
                {
                    sb.Append($"wierzchołek {row} połączone z: ");
                    for (int column = 0; column < _matrix.GetLength(1); column++)
                    {
                        if (_matrix[row,column] != 0 )
                            sb.Append($"{column} ");
                    }
                    sb.Append($"\n");
                }

                return sb.ToString();
            }
        }
    }
}
