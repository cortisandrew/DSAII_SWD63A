using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class GraphSearchResult
    {
        string sourceVertex;
        Dictionary<string, string> prev;

        public GraphSearchResult(string sourceVertex, Dictionary<string, string> prev)
        {
            this.sourceVertex = sourceVertex;
            this.prev = prev;
        }

        public List<string> PathToSource(string otherVertex)
        {
            List<string> pathToSource = new List<string>();
            pathToSource.Add(otherVertex);
            string currentVertex = otherVertex;

            // keep looping until we have arrive back at the source...
            while (currentVertex != sourceVertex)
            {
                // find the previous vertex
                string previousVertex = prev[currentVertex];
                // add this to the path
                pathToSource.Add(
                    previousVertex
                    );
                // move forward
                currentVertex = previousVertex;
            }

            return pathToSource;
        }

        public List<string> PathToVertex(string vertex)
        {
            List<string> result = PathToSource(vertex);
            result.Reverse();
            return result;
        }
    }
}
