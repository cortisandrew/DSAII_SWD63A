using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class AdjacencyMatrixGraphImplementation
    {
        private int numberOfVertices; // 1 space
        private int[,] adjacencyMatrix; // once initialised, this will take up |V| x |V| space

        private Dictionary<string, int> vertexNames = new Dictionary<string, int>(); // about |V| space
        private Dictionary<int, string> indexToVertexNameMapping = new Dictionary<int, string>(); // about |V| space
        // alternative using jagged arrays
        //private int[][] adjacencyMatrix;


        public AdjacencyMatrixGraphImplementation(int numberOfVertices)
        {
            this.numberOfVertices = numberOfVertices;
            adjacencyMatrix = new int[numberOfVertices, numberOfVertices]; // this creates a square matrix with numberOfVertices squared places
            
            /* possible setup... might be improved
            adjacencyMatrix = new int[numberOfVertices][];

            for (int i = 0; i < numberOfVertices; i++)
            {
                adjacencyMatrix[i] = new int[numberOfVertices - i];
            }
            */
        }

        public void NameVertex(int index, string vertexName)
        {
            if (vertexNames.ContainsKey(vertexName))
            {
                throw new ArgumentException("You cannot add a vertex with the same name", "vertexName");
            }

            if (indexToVertexNameMapping.ContainsKey(index))
            {
                throw new ArgumentException("You cannot give multiple names to the same index", "index");
            }

            if (index < 0 || index >= numberOfVertices)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            vertexNames.Add(vertexName, index);
            indexToVertexNameMapping.Add(index, vertexName);
        }

        public void AddEdge(string vertexNameOne, string vertexNameTwo)
        {
            if (vertexNameOne == vertexNameTwo)
            {
                throw new ArgumentException("Reflexive edges (from a vertex to itself) are not allowed", "vertexNameTwo");
            }

            // get the index from the vertex names!
            int indexOne = vertexNames[vertexNameOne];
            int indexTwo = vertexNames[vertexNameTwo];

            // set the edge in the adjacency matrix!
            adjacencyMatrix[indexOne, indexTwo] = 1;
            adjacencyMatrix[indexTwo, indexOne] = 1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("graph G {");

            for (int i = 0; i < numberOfVertices; i++)
            {
                for (int j = i+1; j < numberOfVertices; j++) // this avoids having double edges, because the graph is undirected with no reflexive edges!
                {
                    if (adjacencyMatrix[i, j] == 1) // look up the adjacency matrix, if the vertices are adjacent, then we have an edge
                    {
                        sb.AppendLine($"{indexToVertexNameMapping[i]}--{indexToVertexNameMapping[j]}");
                    }
                }
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        public int Degree(string v)
        {
            int index = vertexNames[v]; // get the row/column of vertex V

            int degree = 0;

            // this loop will repeat itself numberOfVertices times (i.e. |V|)
            for (int i = 0; i < numberOfVertices; i++)
            {
                // go through each and every item in the row
                if (adjacencyMatrix[index, i] != 0)
                {
                    // find the non-zero elements
                    // this indicates an adjacent vertex / edge
                    degree++; // add 1 to the degree
                }
            }

            return degree;
        }

        public bool IsAdjacent(string u, string v)
        {
            int indexOne = vertexNames[u]; // about constant time
            int indexTwo = vertexNames[v]; // about constant time

            // reading from / writing to a specific location in matrix is also constant time
            if (adjacencyMatrix[indexOne, indexTwo] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<string> GetAllAdjacencies(string v)
        {
            List<string> adjacencies = new List<string>();

            int index = vertexNames[v]; // get the row/column of vertex V

            // this loop will repeat itself numberOfVertices times (i.e. |V|)
            for (int i = 0; i < numberOfVertices; i++)
            {
                // go through each and every item in the row
                if (adjacencyMatrix[index, i] != 0)
                {
                    adjacencies.Add(indexToVertexNameMapping[i]); // amortised O(1)
                }
            }

            return adjacencies;
        }
    }
}
