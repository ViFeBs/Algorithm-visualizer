using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_visualizer.model
{
    public class Graph
    {
        private int vertices; // Número de vértices
        private List<int>[] adjList; // Lista de adjacência

        public Graph(int v)
        {
            vertices = v;
            adjList = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adjList[i] = new List<int>();
            }
        }

        public List<int>[] getAdjlist() { return adjList; }
        public int getVertices() { return vertices; }

        // Adicionar aresta entre dois nós
        public void AddEdge(int v, int w)
        {
            adjList[v].Add(w);
            adjList[w].Add(v); // Grafo não direcionado
        }

        // Método para obter os vizinhos de um nó
        public List<int> GetNeighbors(int v)
        {
            return adjList[v];
        }

        public int GetVerticesCount()
        {
            return vertices;
        }

        // Método para gerar grafo aleatório
        public static Graph GenerateRandomGraph(int vertices, int edges)
        {
            Graph graph = new Graph(vertices);
            Random rand = new Random();

            // Garantir que todos os vértices tenham pelo menos uma conexão
            for (int i = 0; i < vertices - 1; i++) { 
                graph.AddEdge(i, i + 1); 
            }

            int edgeCount = 0;

            while (edgeCount < edges)
            {
                int v1 = rand.Next(vertices); // Nó aleatório 1
                int v2 = rand.Next(vertices); // Nó aleatório 2

                if (v1 != v2 && !graph.GetNeighbors(v1).Contains(v2)) // Evitar duplicatas e loops
                {
                    graph.AddEdge(v1, v2);
                    edgeCount++;
                }
            }

            return graph;
        }

        public string GetGraphAsText()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < adjList.Length; i++)
            {
                sb.Append($"{i}: ");
                foreach (var neighbor in adjList[i])
                {
                    sb.Append($"{neighbor} ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public int GetTreeDepth(int root)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<(int node, int level)> queue = new Queue<(int, int)>();
            queue.Enqueue((root, 0));

            int maxDepth = 0;

            while (queue.Count > 0)
            {
                var (node, level) = queue.Dequeue();
                if (visited.Contains(node)) continue;

                visited.Add(node);
                maxDepth = Math.Max(maxDepth, level);

                foreach (int neighbor in adjList[node]) // Adapte GetNeighbors ao seu grafo
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue((neighbor, level + 1));
                }
            }

            return maxDepth;
        }

    }
}
