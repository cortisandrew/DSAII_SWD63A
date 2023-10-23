using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class AdjacencyListGraphImplementation
    {
        // Array of linked lists
        // Each linked list would represent the adjacencies of the corresponding vertex
        // LinkedList<string>[] adjacencyList;

        // This is a hashtable
        // The key is the name of the vertex
        // The value (for each vertex) is a linked list of adjacencies
        Dictionary<string,          // key = vertex name
            LinkedList<string>>     // value = linked list of adjacent vertices
                adjacencyList = new Dictionary<string, LinkedList<string>>();

        public void AddVertex(string vertexName)
        {
            if (adjacencyList.ContainsKey(vertexName))
            {
                throw new ArgumentException("You cannot add the same vertex twice!");
            }

            adjacencyList.Add(vertexName, new LinkedList<string>());
        }

        public void AddEdge(string vertexOne, string vertexTwo)
        {
            if (!adjacencyList.ContainsKey(vertexOne) || !adjacencyList.ContainsKey(vertexTwo))
            {
                throw new ArgumentException("You cannot add an edge if the vertex does not exist!");
            }

            // to add next lecture check that we don't add the same edge multiple times!
            adjacencyList[vertexOne].AddLast(vertexTwo);
            adjacencyList[vertexTwo].AddLast(vertexOne);
        }

        public LinkedList<string> GetAllAdjacencies(string v)
        {
            return adjacencyList[v];
        }
    }
}
