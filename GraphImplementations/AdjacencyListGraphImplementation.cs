using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class AdjacencyListGraphImplementation
    {
        /*
        // for every vertex v, I want to store a linked list which will store all the adjacencies of v
        private LinkedList<string>[] adjacencyList = new LinkedList<string>[]
        {
            new LinkedList<string>() { "2", "3" }, // vertex 1
            new LinkedList<string>() { "1" },       // vertex 2
            new LinkedList<string>() { "1"}         // vertex 3
        };
        */


        /*
         * "1" -> { "2", "3" }
         * "2" -> { "1" }
         * "3" -> { "1" }
         * 
         */
        private Dictionary<
            string,                 // vertexName
            LinkedList<string>>     // the linked list containing all the adjacencies of the vertex mapped to by the key
            adjacencyList = new Dictionary<string, LinkedList<string>>();

        public void AddVertex(string v)
        {
            adjacencyList.Add(v, new LinkedList<string>());    
        }

        internal void AddEdge(string v1, string v2)
        {
            if (!adjacencyList.ContainsKey(v1))
            {
                // v1 is not yet a vertex...
                AddVertex(v1); // add it now...
                // or else
                // throw new Exception();
            }

            if (!adjacencyList.ContainsKey(v2))
            {
                // same as above...
                AddVertex(v2);
            }

            // add an edge between v1 and v2
            // this means that now v2 is adajacent to v1 and vice-versa...
            adjacencyList[v1].AddLast(v2);
            adjacencyList[v2].AddLast(v1);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("graph G {");

            foreach (string getVertex in adjacencyList.Keys)
            {
                // we are obtaining the vertices one by one....
                LinkedList<string> adjacentToVertex = adjacencyList[getVertex];

                foreach(string getAdjacentVertex in adjacentToVertex)
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
                        sb.AppendLine($"{getVertex}--{getAdjacentVertex};");
                    }
                }
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
