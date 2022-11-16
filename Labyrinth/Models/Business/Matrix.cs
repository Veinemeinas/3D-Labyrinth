using Labyrinth.Services;

namespace Labyrinth.Models.Business
{
    internal static class Matrix
    {
        public static Point GetStartingPoint(this List<List<List<char>>> matrix)
        {
            char startingPoint = 'S';
            var zLength = matrix.Count;
            var xLength = matrix[0].Count;
            var yLength = matrix[0][0].Count;

            for (int i = 0; i < zLength; i++)
            {
                for (int j = 0; j < xLength; j++)
                {
                    for (int k = 0; k < yLength; k++)
                    {
                        if (matrix[i][j][k] == startingPoint)
                        {
                            return new Point() { X = j, Y = k, Z = i };
                        }
                    }
                }
            }

            throw new Exception("Starting point \"D\" don't find");
        }

        public static List<Path> GetMyTrips(List<List<List<char>>> matrix, Point start, int counter = 0)
        {

            var result = new List<Path>();
            var newMatrix = GetMatrix(matrix, start);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Layer: {start.Z + 1}\n");
            newMatrix[start.Z].PrintLayer();
            Thread.Sleep(30);
            Console.SetCursorPosition(0, 0);


            if (newMatrix.IsPontExit(start))
            {
                Console.WriteLine("\nExit Found.");
                Thread.Sleep(2000);
                Console.Clear();

                result.Add(new Path() { ExitMatrix = newMatrix, StepCounter = counter });
                return result;
            }

            counter++;

            // To the left.
            if (newMatrix[start.Z][start.X][start.Y - 1] == '.') { result.AddRange(GetMyTrips(newMatrix, new Point() { X = start.X, Y = start.Y - 1, Z = start.Z }, counter)); }
            // To the forward.
            if (newMatrix[start.Z][start.X - 1][start.Y] == '.') { result.AddRange(GetMyTrips(newMatrix, new Point() { X = start.X - 1, Y = start.Y, Z = start.Z }, counter)); }
            // To the right.
            if (newMatrix[start.Z][start.X][start.Y + 1] == '.') { result.AddRange(GetMyTrips(newMatrix, new Point() { X = start.X, Y = start.Y + 1, Z = start.Z }, counter)); }
            // To the back.
            if (newMatrix[start.Z][start.X + 1][start.Y] == '.') { result.AddRange(GetMyTrips(newMatrix, new Point() { X = start.X + 1, Y = start.Y, Z = start.Z }, counter)); }
            // To the top.
            if (newMatrix[start.Z + 1][start.X][start.Y] == '.') { result.AddRange(GetMyTrips(newMatrix, new Point() { X = start.X, Y = start.Y, Z = start.Z + 1 }, counter)); }
            // To the buttom.
            if (newMatrix[start.Z - 1][start.X][start.Y] == '.') { result.AddRange(GetMyTrips(newMatrix, new Point() { X = start.X, Y = start.Y, Z = start.Z - 1 }, counter)); }

            return result;
        }

        private static bool IsPontExit(this List<List<List<char>>> matrix, Point point)
        {
            if (point.X == 0 || point.Y == 0 || point.Z == 0 || point.Z == matrix.Count - 1 || point.X == matrix[0].Count - 1 || point.Y == matrix[0][0].Count - 1)
            {
                return true;
            }

            return false;
        }

        private static List<List<List<char>>> GetMatrix(List<List<List<char>>> matrix, Point point)
        {
            List<List<List<char>>> newMap = new List<List<List<char>>>();

            for (int i = 0; i < matrix.Count; i++)
            {
                List<List<char>> newMapLayer = new List<List<char>>();
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    List<char> mapLine = new List<char>();
                    mapLine.AddRange(matrix[i][j]);
                    newMapLayer.Add(mapLine);
                }
                newMap.Add(newMapLayer);
            }
            newMap[point.Z][point.X][point.Y] = ' ';

            return newMap;
        }
    }
}
