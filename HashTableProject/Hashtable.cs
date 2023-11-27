using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProject
{
    public class Hashtable<Key, Value>
    {
        public int Count { get; private set; } = 0;

        private const int DEFAULT_LENGTH = 4;
        //private Bucket<Key, Value>[] array = new Bucket<Key, Value>[DEFAULT_LENGTH];
        // Will be using chaining for collision resolution
        private LinkedList<Bucket<Key, Value>>[] array = new LinkedList<Bucket<Key, Value>>[DEFAULT_LENGTH];


        public void Add(Key k, Value v)
        {
            if (k == null)
            {
                throw new ArgumentNullException(nameof(k), "The key cannot be null");
            }

            Bucket<Key, Value> newBucket = new Bucket<Key, Value>(k, v);
            int pos = (k.GetHashCode() & 0x7FFFFFFF) % array.Length;

            if (array[pos] == null)
            {
                array[pos] = new LinkedList<Bucket<Key, Value>>();
                array[pos].AddLast(newBucket);
            }
            else
            {
                // collision: a item already exists here,
                // add to the end of the linked list
                array[pos].AddLast(newBucket);
            }
        }

        public void Update(Key k, Value newValue)
        {
            throw new NotImplementedException();
        }

        public void Delete(Key k)
        {
            throw new NotImplementedException();
        }

        public Value Get(Key k)
        {
            if (k == null)
            {
                throw new ArgumentNullException(nameof(k), "The key cannot be null");
            }

            int pos = (k.GetHashCode() & 0x7FFFFFFF) % array.Length;

            var linkedList = array[pos];

            foreach (var bucket in linkedList)
            {
                if (bucket.K == null)
                {
                    throw new Exception("This exception should never happen, because buckets cannot have null keys!");
                }

                // this bucket is the bucket with the correct key
                if (bucket.K.Equals(k))
                {
                    return bucket.V;
                }

                // if the bucket does not contain the correct key, keep looking in the next bucket
            }

            // we have gone through the entire linked list and still haven't found the bucket
            // the key is not here!
            throw new KeyNotFoundException();
        }
    }
}
