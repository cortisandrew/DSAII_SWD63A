using GraphImplementations;

Graph G = new Graph();

G.AddVertex("A");
G.AddVertex("B");
G.AddVertex("C");
G.AddVertex("D");
G.AddVertex("E");
G.AddVertex("F");
G.AddVertex("G");
G.AddVertex("H");

G.AddEdge("A", "B");
G.AddEdge("A", "C");
G.AddEdge("B", "D");
G.AddEdge("B", "F");
G.AddEdge("C", "D");
G.AddEdge("D", "E");
G.AddEdge("F", "G");
G.AddEdge("F", "H");
G.AddEdge("G", "H");

var prev = G.BFS("A");

// Find a path from C back to A and print it out
Console.WriteLine(
    String.Join(", ", prev.PathToSource("C")));

Console.WriteLine(
    String.Join(", ", prev.PathToVertex("C")));

Console.WriteLine(
    String.Join(", ", prev.PathToSource("H")));


int a = 0;
a = a + 1;


/*
AdjacencyListGraphImplementation adjacencyListGraphImplementation = new AdjacencyListGraphImplementation();

adjacencyListGraphImplementation.AddVertex("A");
adjacencyListGraphImplementation.AddVertex("B");
adjacencyListGraphImplementation.AddVertex("C");
adjacencyListGraphImplementation.AddVertex("D");
adjacencyListGraphImplementation.AddVertex("E");

adjacencyListGraphImplementation.AddEdge("A", "B");
adjacencyListGraphImplementation.AddEdge("A", "E");
adjacencyListGraphImplementation.AddEdge("B", "C");
adjacencyListGraphImplementation.AddEdge("B", "D");
adjacencyListGraphImplementation.AddEdge("B", "E");
adjacencyListGraphImplementation.AddEdge("C", "D");
adjacencyListGraphImplementation.AddEdge("D", "E");

LinkedList<string> adjacencies = adjacencyListGraphImplementation.GetAllAdjacencies("B");
Console.WriteLine($"The adjacencies of B are {String.Join(", ", adjacencies)}");

int a = 0;
a = a + 1;
*/

/*
AdjacencyMatrixGraphImplementation myGraph = new AdjacencyMatrixGraphImplementation(5);

/*
myGraph.NameVertex(0, "A");
myGraph.NameVertex(1, "B");
myGraph.NameVertex(2, "C");
myGraph.NameVertex(3, "D");
myGraph.NameVertex(4, "E");
*/

/*
myGraph.AddVertex("A");

myGraph.AddEdge("A", "B");
myGraph.AddEdge("A", "E");
myGraph.AddEdge("B", "C");
myGraph.AddEdge("B", "D");
myGraph.AddEdge("B", "E");
myGraph.AddEdge("C", "D");
myGraph.AddEdge("D", "E");


Console.WriteLine($"The degree of A is {myGraph.Degree("A")}");
Console.WriteLine($"The degree of B is {myGraph.Degree("B")}");
Console.WriteLine($"The degree of C is {myGraph.Degree("C")}");

Console.WriteLine($"The adjacencies of B are {String.Join(", ", myGraph.GetAllAdjacencies("B"))}");

Console.WriteLine($"Are A and B adjacent? {myGraph.IsAdjacent("A", "B")}");

Console.WriteLine(myGraph);
*/
