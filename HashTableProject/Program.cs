using HashTableProject;

Hashtable<int, string> hashTable = new Hashtable<int, string>();

hashTable.Add(4, "Four");
hashTable.Add(3, "Three");
hashTable.Add(0, "Zero");

Console.WriteLine(hashTable.Get(3));
Console.WriteLine(hashTable.Get(4));
Console.WriteLine(hashTable.Get(0));
Console.WriteLine(hashTable.Get(8));
//Console.WriteLine(hashTable.Get(2));
//hashTable.Add(0, "Zero");

