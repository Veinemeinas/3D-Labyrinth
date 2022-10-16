using Path = Labyrinth.Models.Path;

namespace Labyrinth.Services
{
    internal static class Results
    {
        public static int GetMin(this List<Path> pathes)
        {
            var ordered = pathes.OrderBy(p => p.StepCounter).ToList();
            return ordered[0].StepCounter;
        }

        public static int GetMax(this List<Path> pathes)
        {
            var ordered = pathes.OrderByDescending(p => p.StepCounter).ToList();
            return ordered[0].StepCounter;
        }

        public static double GetAverage(this List<Path> pathes)
        {
            return pathes.Count > 0 ? Math.Round(pathes.Average(p => p.StepCounter), 2) : 0;
        }

        public static int GetMedian(this List<Path> pathes)
        {
            int counter = pathes.Count();
            var ordered = pathes.OrderBy(p => p.StepCounter).ToList();

            if (counter % 2 == 1)
            {
                var middle = (int)Math.Floor((double)counter / 2);
                return ordered[middle].StepCounter;
            }
            else
            {
                var middle = counter / 2;
                return (ordered[middle - 1].StepCounter + ordered[middle].StepCounter) / 2;
            }
        }
    }
}
