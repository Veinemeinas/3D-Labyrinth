namespace Labyrinth.Services
{
    internal class FileReader
    {
        public static async Task<List<List<List<char>>>> GetLabyrinth(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File \"{fileName}\" not found!");
            }

            var labyrinthLines = await File.ReadAllLinesAsync(fileName);

            List<List<List<char>>> labyrinth3D = new List<List<List<char>>>();
            List<List<char>> labyrinth = new List<List<char>>();

            foreach (var line in labyrinthLines)
            {
                if (line == " ")
                {
                    labyrinth3D.Add(labyrinth);
                    labyrinth = new List<List<char>>();
                }
                else
                {
                    labyrinth.Add(line.ToCharArray().ToList());
                }
            }

            return labyrinth3D;
        }
    }
}
