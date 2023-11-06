using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public interface IWeightedVertex
    {
        /// <summary>
        /// The Name represents a value that uniquely identifies a vertex!
        /// </summary>
        string Name { get; }

        void AddEdge(string adjacentVertex, int weight);

        // choose the other option
        //void AddEdge(IWeightedVertex otherVertex);

        /// <summary>
        /// Returns the degree of the current instance
        /// </summary>
        /// <returns>A value >= 0, representing the degree of this instance</returns>
        int Degree();

        WeightedAdjacencyList Adjacencies();

        bool IsAdjacent(string otherVertex);

    }
}
