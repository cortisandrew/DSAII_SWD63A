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
    }
}
