namespace GraphImplementations
{
    public class WeightedAdjacencyList
    {
        /// <summary>
        /// This adjacency list belongs to this vertex...
        /// </summary>
        public string VertexName { get; private set; }

        public Dictionary<
            string,             // Adjacent Vertex
            int                 // Weight of the Edge
            > AdjacentVertexNames { get; private set; } = new Dictionary< string, int >();

        public WeightedAdjacencyList(string vertexName)
        {
            VertexName = vertexName;
        }

        public bool Add(string adjacentVertex, int weight)
        {
            if (AdjacentVertexNames.ContainsKey(adjacentVertex))
                return false;

            AdjacentVertexNames.Add(adjacentVertex, weight);
            return true;
        }

        public int Degree()
        {
            return AdjacentVertexNames.Count;
        }

        public bool IsAdjacent(string otherVertex)
        {
            return AdjacentVertexNames.ContainsKey(otherVertex);
        }
    }
}