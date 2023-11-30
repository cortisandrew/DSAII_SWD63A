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

        public double LoadFactor { get {
                return (double)Count / array.Length; 
            } }

        private const double MAX_LOAD_FACTOR = 0.9; // the max load factor directly indicates how much extra space we need (as a minimum)

        public bool ContainsKey(Key k)
        {
            if (k == null)
            {
                throw new ArgumentNullException(nameof(k), "The key cannot be null");
            }

            int pos = (k.GetHashCode() & 0x7FFFFFFF) % array.Length;

            var linkedList = array[pos];

            if (linkedList == null)
            {
                // no linked list found - which means that there are no items in this position/index
                return false;
            }

            foreach (var bucket in linkedList)
            {
                if (bucket.K == null)
                {
                    throw new Exception("This exception should never happen, because buckets cannot have null keys!");
                }

                // this bucket is the bucket with the correct key
                if (bucket.K.Equals(k))
                {
                    return true;
                }

                // if the bucket does not contain the correct key, keep looking in the next bucket
            }

            // we have gone through the entire linked list and still haven't found the bucket
            // the key is not here!
            return false;
        }

        public void Add(Key k, Value v)
        {
            if (k == null)
            {
                throw new ArgumentNullException(nameof(k), "The key cannot be null");
            }

            if (ContainsKey(k))
            {
                // the key already exists - you cannot add the same key twice
                throw new Exception("The key already exists! you cannot add the same key twice!");
            }

            // array growth to stop load factor from becoming too large
            if (LoadFactor >= MAX_LOAD_FACTOR)
            {
                // we have an issue! Load factor is very high!
                // we can create a new and larger array that contains all of the items
                LinkedList<Bucket<Key, Value>>[] newArray = new LinkedList<Bucket<Key, Value>>[array.Length * 2];

                // copy all of the old data over to the newArray
                foreach (var linkedList in array)
                {
                    if (linkedList == null)
                    {
                        // linked list is empty
                        continue;
                    }

                    foreach (var bucket in linkedList)
                    {
                        // an item that I would like to copy over to the new array
                        // the new bucket should contain the key and value from the old bucket
                        Bucket<Key, Value> copyBucket = new Bucket<Key, Value>(bucket.K, bucket.V);
                        int newPos = (bucket.K.GetHashCode() & 0x7FFFFFFF) % newArray.Length;

                        if (newArray[newPos] == null)
                        {
                            newArray[newPos] = new LinkedList<Bucket<Key, Value>>();
                            newArray[newPos].AddLast(copyBucket);
                        }
                        else
                        {
                            // collision: a item already exists here,
                            // add to the end of the linked list
                            newArray[newPos].AddLast(copyBucket);
                        }
                    }
                }

                // now all the items in the old array have been copied to the new array
                // replace the old array with the new array containing all of the items
                array = newArray;
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

            Count++;
        }

        public void Update(Key k, Value newValue)
        {
            if (k == null)
            {
                throw new ArgumentNullException(nameof(k), "The key cannot be null");
            }

            int pos = (k.GetHashCode() & 0x7FFFFFFF) % array.Length;

            var linkedList = array[pos];

            if (linkedList == null)
            {
                throw new KeyNotFoundException();
            }

            foreach (var bucket in linkedList)
            {
                if (bucket.K == null)
                {
                    throw new Exception("This exception should never happen, because buckets cannot have null keys!");
                }

                // this bucket is the bucket with the correct key
                if (bucket.K.Equals(k))
                {
                    bucket.V = newValue;
                    return;
                }
            }

            // we have gone through the entire linked list and still haven't found the bucket
            // the key is not here!
            throw new KeyNotFoundException();
        }

        public void Delete(Key k)
        {
            // Exercise! TODO
            throw new NotImplementedException("Exercise!");
        }

        public Value Get(Key k)
        {
            if (k == null)
            {
                throw new ArgumentNullException(nameof(k), "The key cannot be null");
            }

            int pos = (k.GetHashCode() & 0x7FFFFFFF) % array.Length;

            var linkedList = array[pos];

            if (linkedList == null)
            {
                // the location does not have any keys at all - therefore the key you want to get does not exist
                // throw an Exception
                throw new KeyNotFoundException();
            }

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
