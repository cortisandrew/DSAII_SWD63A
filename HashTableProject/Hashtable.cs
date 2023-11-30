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
