namespace GraphImplementations
{
    public class AdjacencyList
    {

        #region optionally think about adding something like this if you need it...
        // If we know that each vertex will only be used in one graph only,
        // then you might consider something like the below
        // this will allow each vertex instance with the same name to have a single point of reference for its adjacencies
        // and avoid inconsistencies
        // private static Dictionary<string, HashSet<string>> allAdjacencies = new Dictionary<string, HashSet<string>>();
        #endregion

        /// <summary>
        /// This adjacency list belongs to this vertex...
        /// </summary>
        public string VertexName { get; private set; }

        public HashSet<string> AdjacentVertexNames { get; private set; } = new HashSet<string>();

        public AdjacencyList(string vertexName)
        {
            VertexName = vertexName;

            #region hidden comments
            /*
            if (AdjacencyList.allAdjacencies.ContainsKey(vertexName))
            {
                AdjacentVertexNames = allAdjacencies[vertexName];
            }
            */
            #endregion
        }

        public bool Add(string adjacentVertex)
        {
            if (AdjacentVertexNames.Contains(adjacentVertex))
                return false;

            AdjacentVertexNames.Add(adjacentVertex);
            return true;
        }

        public int Degree()
        {
            return AdjacentVertexNames.Count;
        }

        public bool IsAdjacent(string otherVertex)
        {
            return AdjacentVertexNames.Contains(otherVertex);
        }
    }
}