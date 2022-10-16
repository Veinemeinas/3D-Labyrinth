using Labyrinth.Models;
using Labyrinth.Models.Business;
using Labyrinth.Services;

var labyrinth = await FileReader.GetLabyrinth("lab.txt");

Point startingPoint = labyrinth.GetStartingPoint();

var pathes = Matrix.GetMyTrips(labyrinth, startingPoint);

Console.WriteLine($"Found {pathes.Count} exit points!");
Console.WriteLine($"Shortest {pathes.GetMin()}");
Console.WriteLine($"Longest {pathes.GetMax()}");
Console.WriteLine($"Average {pathes.GetAverage()}");
Console.WriteLine($"Median {pathes.GetMedian()}");

Console.WriteLine("\n3D labyrinth.\n");

labyrinth.PrintAllLabyrinth();

Console.ReadLine();