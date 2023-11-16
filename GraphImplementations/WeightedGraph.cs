using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class WeightedGraph
    {
        Dictionary<string, IWeightedVertex> vertices = new Dictionary<string, IWeightedVertex>();

        public void AddVertex(string vertexName)
        {
            vertices.Add(
                vertexName,
                new WeightedVertex(vertexName));
        }

        public void AddEdge(string vertexName, string otherVertex, int weight)
        {
            vertices[vertexName].AddEdge(otherVertex, weight);
            vertices[otherVertex].AddEdge(vertexName, weight);
        }

        int Degree(string vertexName)
        {
            return vertices[vertexName].Degree();
        }

        public WeightedAdjacencyList Adjacencies(string vertexName)
        {
            return vertices[vertexName].Adjacencies();
        }

        public GraphSearchResult Dijkstra(string sourceVertex)
        {
            // Initialisation for running the algorithm is within this region
            #region Initialisation
            List<string> Q = new List<string>();    // Q is going to be a priority queue
                                                    // The ArrayBasedVector is NOT the most efficient structure to use
                                                    // However, it will be simpler for the first example
                                                    // Every time you want to dequeue the minimum distance, you have to search through the whole Q

            Dictionary<string, string> prev = new Dictionary<string, string>();
            Dictionary<string, long> dist = new Dictionary<string, long>();

            // This loop is repeated |V| times. The operations within the loop are average or amortised O(1) times
            // The total time is about |V|
            foreach (var vertex in vertices) {
                Q.Add(vertex.Key); // Key is the vertex name (and identifier)
                
                // prev[vertex.Key] = null; // We consider a missing key to indicate that the prev is null

                // Options to store the distance to the source vertex
                // dist[vertex.Key] = double.PositiveInfinity;
                // dist[vertex.Key] = null;
                // dist[vertex.Key] = long.MaxValue;
                dist[vertex.Key] = long.MaxValue; // chosen approach in class
            }

            // Average O(1) time
            dist[sourceVertex] = 0; // distance of the source to itself is 0
            #endregion

            // Main code starts here...
            #region Main Loop

            // Outer loop is repeated |V| times
            while (!Q.IsEmpty())
            {
                // remove the vertex with minimum dist from Q and obtain that vertex as u
                // This method takes about |V| time
                string u = Q.RemoveMin(dist);

                WeightedAdjacencyList adjacencies = Adjacencies(u);

                // for all vertices v adjacent to u
                // The inner loop is repeated 2|E| times (using the handshaking theorem)
                foreach (KeyValuePair<string, int> v in adjacencies.AdjacentVertexNames)
                {
                    long wPrime = dist[u] + v.Value; // long of alternate path
                    if (wPrime < dist[v.Key]) // a shorter path is found
                    {
                        dist[v.Key] = wPrime;
                        prev[v.Key] = u;

                        // When Q is a Heap:
                        // option i
                        // descrease Key for v...

                        // option ii
                        // add another copy of v to the heap...
                    }
                }
            }
            #endregion

            return new GraphSearchResult(sourceVertex, prev, dist);
        }

        public static GraphSearchResult Dijkstra(WeightedGraph g, string sourceVertex)
        {
            return g.Dijkstra(sourceVertex);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("graph G {");

            foreach (string getVertex in vertices.Keys)
            {
                var adjacencyList = vertices[getVertex].Adjacencies();
                // we are obtaining the vertices one by one....
                List<string> adjacentToVertex = adjacencyList.AdjacentVertexNames.Keys.ToList<string>();

                foreach (string getAdjacentVertex in adjacentToVertex)
                {
                    // we have found an edge!
                    // the edge is from getVertex to getAdjacentVertex

                    if (getAdjacentVertex.CompareTo(getVertex) < 0)
                    {
                        // getAdjacentVertex is in front of getVertex in the alphabetical order
                        // do not add, we will add this edge when we are considering the adjacency with getVertex as the first vertex
                    }
                    else
                    {
                        sb.AppendLine($"{getVertex}--{getAdjacentVertex} [label=\"{adjacencyList.AdjacentVertexNames[getAdjacentVertex]}\"];");
                    }
                }
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
