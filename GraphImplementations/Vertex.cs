using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class Vertex : IVertex
    {
        public string Name { get; private set;}

        public AdjacencyList AdjacencyList { get; private set; }

        public Vertex(string name)
        {
            Name = name;
            AdjacencyList = new AdjacencyList(name);
        }

        public void AddEdge(string adjacentVertex)
        {
            AdjacencyList.Add(adjacentVertex);
        }

        // of course you can.. but you will require to change the interface IVertex... (only should be done at design stage)
        // public List<string> Adjacencies;

        public AdjacencyList Adjacencies()
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
