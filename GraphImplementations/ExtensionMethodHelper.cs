using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public static class ExtensionMethodHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Q"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        /// <remarks>Takes Theta(|Q|) time</remarks>
        public static T RemoveMin<T>(this List<T> Q, Dictionary<T, long> dist) where T : class
        {
            // Inefficient
            #region find u with smallest distance
            T u = Q[0]; // temporarily select the first element as the element with minimum distance
            long minDistance = dist[u];

            // Search (the rest of) Q to find the vertex with the minimum distance
            for (int i = 1; i < Q.Count; i++)
            {
                T cursor = Q[i];
                if (dist[cursor] < minDistance) // we found a vertex with a smaller distance!
                {
                    // replace the minimum found!
                    u = cursor;
                    minDistance = dist[cursor];
                }
            }
            #endregion

            // u is the vertex with minimum distance!
            // we have found the vertex that we have been looking for
            // remove u from Q
            Q.Remove(u); // inefficient method!

            return u;
        }

        public static bool IsEmpty<T>(this List<T> Q)
        {
            return Q.Count == 0;
        }

        public static void Swap<T>(this List<T> myList, int indexOne, int indexTwo)
        {
            T temp = myList[indexOne];
            myList[indexOne] = myList[indexTwo];
            myList[indexTwo] = temp;
        }
    }
}
