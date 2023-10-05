// See https://aka.ms/new-console-template for more information
using Vector_Example;

DoublingGrowthStrategy selectedGrowthStrategy = new DoublingGrowthStrategy();
//IncrementalGrowthStrategy selectedGrowthStrategy = new IncrementalGrowthStrategy(1000);

ArrayBasedVector<int> arrayBasedVector = new ArrayBasedVector<int>(selectedGrowthStrategy);

int numberOfAppends = 1000000;

for (int i = 0; i < numberOfAppends; i++)
    arrayBasedVector.Append(1);


Console.WriteLine(arrayBasedVector);
