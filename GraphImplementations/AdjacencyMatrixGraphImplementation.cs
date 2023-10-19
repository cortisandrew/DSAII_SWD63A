using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class AdjacencyMatrixGraphImplementation
    {
        private int numberOfVertices;
        private int[,] adjacencyMatrix;

        private Dictionary<string, int> vertexNames = new Dictionary<string, int>();
        private Dictionary<int, string> indexToVertexNameMapping = new Dictionary<int, string>();
        // alternative using jagged arrays
        //private int[][] adjacencyMatrix;


        public AdjacencyMatrixGraphImplementation(int numberOfVertices)
        {
            this.numberOfVertices = numberOfVertices;
            adjacencyMatrix = new int[numberOfVertices, numberOfVertices];
            
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

    }
}
