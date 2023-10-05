using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector_Example
{
    /// <summary>
    /// This is a data structure
    /// It is a concrete implementation of the Abstract Data Type Vector
    /// </summary>
    public class ArrayBasedVector<T>
    {
        private const int DEFAULT_LENGTH = 1;

        private int count = 0;
        public int Count { 
            get => count;
            private set => count = value;
        }

        private T[] array = new T[DEFAULT_LENGTH];

        private IArrayGrowthStrategy growthStrategy;

        public ArrayBasedVector(IArrayGrowthStrategy growthStrategy)
        {
            this.growthStrategy = growthStrategy;
        }

        public void InsertAtRank(int rank, T element)
        {
            if (rank < 0 || rank > count)
                throw new ArgumentOutOfRangeException(nameof(rank),
                    $"The rank chosen is outside acceptable range. " +
                    $"Choose a value between 0 and {count} both inclusive");

            if (count == array.Length) // array is full
            {
                // create a new larger array
                T[] newArray = new T[growthStrategy.NewSize(array.Length)];

                #region Commented alternative code
                /*
                // copy all of the elements from the current array to the new array
                for (int i = 0; i < count; i++)
                {
                    newArray[i] = array[i];
                }
                */
                #endregion

                // same as commented code above
                array.CopyTo(newArray, 0);

                // replace the old array with the new array
                array = newArray;
            }
            
            // Shift every element, starting from the last element
            // If you forgot why or how it works, please search this
            for (int i = count - 1; i >= rank; i--)
            {
                array[i + 1] = array[i];
            }

            // place the new element
            array[rank] = element;
            // increment the count
            count++;
        }

        public void Append(T element)
        {
            InsertAtRank(count, element);
        }

        public override string ToString()
        {
            return "[ " + String.Join(", ",
                    array.Take(count)) + " ]";
        }

    }
}
