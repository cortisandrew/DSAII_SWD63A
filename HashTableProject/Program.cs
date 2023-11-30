using HashTableProject;

Hashtable<int, string> hashTable = new Hashtable<int, string>();

hashTable.Add(4, "Four");
hashTable.Add(3, "Three");
hashTable.Add(0, "Zero");
hashTable.Add(1, "One");
hashTable.Add(2, "Two");
hashTable.Add(1453, "1453");
hashTable.Add(2457, "2457");
hashTable.Add(1329, "1329");
hashTable.Add(4242, "4242");



//hashTable.Add(0, "IncorrectValue");

Console.WriteLine($"Load factor is: {hashTable.LoadFactor}");

Console.WriteLine(hashTable.Get(3));
Console.WriteLine(hashTable.Get(4));
Console.WriteLine(hashTable.Get(0));
Console.WriteLine(hashTable.Get(8));
//Console.WriteLine(hashTable.Get(2));
//hashTable.Add(0, "Zero");

