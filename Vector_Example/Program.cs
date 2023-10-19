// See https://aka.ms/new-console-template for more information
using Vector_Example;

DoublingGrowthStrategy selectedGrowthStrategy = new DoublingGrowthStrategy();
//IncrementalGrowthStrategy selectedGrowthStrategy = new IncrementalGrowthStrategy(2);

ArrayBasedVector<int> arrayBasedVector = new ArrayBasedVector<int>(selectedGrowthStrategy);

// n
int numberOfAppends = 1025;

Console.WriteLine($"T(0) = {arrayBasedVector.NumberOfWriteOperations}");

for (int i = 0; i < numberOfAppends; i++)
{
    arrayBasedVector.Append(1);
    Console.WriteLine($"T({(i + 1)}) = {arrayBasedVector.NumberOfWriteOperations}");
}

// Console.WriteLine(arrayBasedVector.NumberOfWriteOperations);
Console.WriteLine($"For {numberOfAppends} appends we required {arrayBasedVector.NumberOfArrayGrowths} array growths");
Console.WriteLine($"Compare this with Log_2(n)={Math.Log2(numberOfAppends)}");



//Console.WriteLine(arrayBasedVector);
