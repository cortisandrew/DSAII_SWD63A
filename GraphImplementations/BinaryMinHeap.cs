using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementations
{
    public class VertexWeightPair
    {
        public string VertexName { get; set; } = String.Empty;
        public int Weight { get; set; }
    }

    public class BinaryMinHeap
    {
        List<VertexWeightPair> v = new List<VertexWeightPair>();
        Dictionary<string, int> mappingFromVertexToIndex = new Dictionary<string, int>();

        //int count = 0;

        public BinaryMinHeap() { }

        public void Add(string vertexName, int weight) {
            var vertexWeightPair = new VertexWeightPair() { VertexName= vertexName, Weight=weight };
            
            v.Add(vertexWeightPair); // Append
            int index = v.Count - 1;

            mappingFromVertexToIndex[vertexName] = index;

            UpHeap(index);
        }

        public string RemoveMin() {
            var vwp = v[0];

            // swap the root with the last item
            v.Swap(0, v.Count - 1);
            v.RemoveAt(v.Count - 1); // remove the element which is now at the end (therefore fast)

            // the above maintains the complete property
            // however the heap order is now lost... because v[0] may have a large weight
            DownHeap(0); // this will fix the heap order

            return vwp.VertexName;
        }

        private void UpHeap(int index)
        {
            if (index == 0)
            {
                // there is no parent to swap with
                return;
            }

            int parentIndex = (int)Math.Floor((index - 1) / 2.0);

            // compare the value of the item at index against the item at the parent's index
            var vwpChild = v[index];
            var vwpParent = v[parentIndex];

            if (vwpChild.Weight < vwpParent.Weight)
            {
                // Swap
                v.Swap(index, parentIndex);
                
                // update the mapping for the swapped elements
                mappingFromVertexToIndex[vwpChild.VertexName] = parentIndex;
                mappingFromVertexToIndex[vwpParent.VertexName] = index;

                // Keep the UpHeap going
                UpHeap(parentIndex);
            }
            // weight of the child >= weight of the parent
            // do nothing!
        }

        private void DownHeap(int index)
        {
            var vwpParent = v[index];

            int leftChildIndex = (index * 2) + 1;
            int rightChildIndex = (index * 2) + 2;

            int smallestChildIndex = -1;

            // do we have any children?
            if (leftChildIndex >= v.Count)
            {
                // there are no children
                return;
            } else if (leftChildIndex == v.Count - 1)
            {
                // there is exactly one child
                smallestChildIndex = leftChildIndex;
            }
            else
            {
                // there are two children
                if (v[leftChildIndex].Weight < v[rightChildIndex].Weight)
                {
                    smallestChildIndex = leftChildIndex;
                } else
                {
                    smallestChildIndex = rightChildIndex;
                }
            }

            // compare the parent with the smallest child and decide whether we need to swap
            if (vwpParent.Weight > v[smallestChildIndex].Weight)
            {
                var smallestChild = v[smallestChildIndex];
                v.Swap(index, smallestChildIndex);
                
                mappingFromVertexToIndex[vwpParent.VertexName] = smallestChildIndex;
                mappingFromVertexToIndex[smallestChild.VertexName] = index;

                DownHeap(smallestChildIndex);
            }
            // else we are ready.. do nothing
        }

        private void ReduceKey(int index, int reducedWeight)
        {
            VertexWeightPair vwp = v[index];

            if (reducedWeight > vwp.Weight)
            {
                throw new Exception("You cannot increase the weight!");
            }

            vwp.Weight = reducedWeight;
            UpHeap(index);
        }

        public void ReduceKey(string vertexName, int reducedWeight)
        {
            int index = mappingFromVertexToIndex[vertexName];

            ReduceKey(index, reducedWeight);
        }

    }
}
