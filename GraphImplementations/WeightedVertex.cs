using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class WeightedVertex : IWeightedVertex
    {
        public string Name { get; private set;}

        public WeightedAdjacencyList AdjacencyList { get; private set; }

        public WeightedVertex(string name)
        {
            Name = name;
            AdjacencyList = new WeightedAdjacencyList(name);
        }

        public void AddEdge(string adjacentVertex, int weight)
        {
            AdjacencyList.Add(adjacentVertex, weight);
        }

        // of course you can.. but you will require to change the interface IWeightedVertex... (only should be done at design stage)
        // public List<string> Adjacencies;

        public WeightedAdjacencyList Adjacencies()
        {
            return AdjacencyList;
        }

        public int Degree()
        {
            return AdjacencyList.Degree();
            // return AdjacencyList.AdjacentVertexNames.Count
        }

        public bool IsAdjacent(string otherVertex)
        {
            return AdjacencyList.IsAdjacent(otherVertex);
        }
    }
}
