using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public interface IVertex
    {
        /// <summary>
        /// The Name represents a value that uniquely identifies a vertex!
        /// </summary>
        string Name { get; }

        void AddEdge(string adjacentVertex);

        // choose the other option
        //void AddEdge(IVertex otherVertex);

        /// <summary>
        /// Returns the degree of the current instance
        /// </summary>
        /// <returns>A value >= 0, representing the degree of this instance</returns>
        int Degree();

        AdjacencyList Adjacencies();

        bool IsAdjacent(string otherVertex);

    }
}
