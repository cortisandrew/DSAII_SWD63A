namespace HashTableProject
{
    internal class Bucket<Key, Value>
    {
        internal Key K { get; private set; }
        internal Value V { get; set; }

        internal Bucket(Key key, Value value)
        {
            if (key == null) { throw new ArgumentNullException("key"); }

            this.K = key;
            this.V = value;
        }
    }
}