using System.Text;

namespace Labyrinth.Services
{
    internal static class Printing
    {
        public static void PrintAllLabyrinth(this List<List<List<char>>> matrix)
        {
            var layersCounter = matrix.Count;

            for (int i = 0; i < layersCounter; i++)
            {
                Console.WriteLine($"Layer {i + 1}");

                PrintLayer(matrix[i]);
            }
        }

        public static void PrintLayer(this List<List<char>> matrix)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var line in matrix)
            {
                stringBuilder.AppendJoin("", line);
                stringBuilder.AppendLine();
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
