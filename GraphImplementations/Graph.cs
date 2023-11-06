using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class Graph
    {
        Dictionary<string, IVertex> vertices = new Dictionary<string, IVertex>();

        public void AddVertex(string vertexName)
        {
            vertices.Add(
                vertexName,
                new Vertex(vertexName));
        }

        public GraphSearchResult DFS(string v)
        {
            // the prev here is replacing the outputGraph in the slides
            Dictionary<string, string> prev = new Dictionary<string, string>();
            
            // visited flags
            HashSet<string> visited = new HashSet<string>();
            visited.Add(v); // the start/source is considered visited

            _DFS(v, visited, prev);

            return new GraphSearchResult(v, prev);
        }

        private void _DFS(string s, HashSet<string> visited, Dictionary<string, string> prev)
        {
            // foreach v element of Adjacencies(s)
            foreach (string v in Adjacencies(s).AdjacentVertexNames)
            {
                // if v is NOT already visited
                if (!visited.Contains(v))
                {
                    // explore v... (go deeper into the Graph)
                    visited.Add(v);
                    prev.Add(v, s); // from v, the previous vertex is s

                    // recursive call
                    _DFS(v, visited, prev);
                }

            }
        }

        public GraphSearchResult BFS(string s)
        {
            // startup of the BFS (slide 1)

            // the prev here is replacing the outputGraph in the slides
            Dictionary<string, string> prev = new Dictionary<string, string>(this.vertices.Count);

            // visited flags
            HashSet<string> visited = new HashSet<string>(this.vertices.Count);

            Queue<string> greyVertices = new Queue<string>();

            greyVertices.Enqueue(s);
            visited.Add(s);

            // slide 2 from here onwards...

            // while we still have places flagged to visit
            while (greyVertices.Count > 0)
            {
                string v = greyVertices.Dequeue();

                // for each u is an element of adjacencies of v
                foreach (string u in Adjacencies(v).AdjacentVertexNames)
                {
                    if (!visited.Contains(u))
                    {
                        visited.Add(u);
                        prev.Add(u, v);
                        greyVertices.Enqueue(u);
                    }
                }
            }

            return new GraphSearchResult(s, prev);
        }

        public void AddEdge(string vertexName, string otherVertex)
        {
            vertices[vertexName].AddEdge(otherVertex);
            vertices[otherVertex].AddEdge(vertexName);
        }

        int Degree(string vertexName)
        {
            return vertices[vertexName].Degree();
        }

        public AdjacencyList Adjacencies(string vertexName)
        {
            return vertices[vertexName].Adjacencies();
        }


    }
}
