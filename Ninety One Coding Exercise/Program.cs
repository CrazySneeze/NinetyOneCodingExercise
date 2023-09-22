

namespace SpreadSheetReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string Directory;
            if (args.Length == 1)
            {
                Directory = args[0];
            }
            else
            {
                Console.WriteLine("Please Type the file directory you would like to read from.");
                Directory = Console.ReadLine();
            }

            SpreadSheet sheet = new SpreadSheet(Directory);
            if (sheet.Sheet.Count > 0)
            {
                getHighestScore(sheet);
            }
        }

        public static void getHighestScore(SpreadSheet sheet)
        {
            int scoreIndex;
            int topScore;

            if (sheet.findRow("Score", out scoreIndex)) 
            { 
                List<int> topScoresIndex = sheet.getMax(scoreIndex, out topScore);
                if (topScoresIndex.Count > 0)
                {
                    List<string> topScoreNames = new List<string>();

                    foreach (int i in topScoresIndex)
                    {
                        topScoreNames.Add($"{sheet.Sheet[i][0]} {sheet.Sheet[i][1]}");
                    }
                    outputTopScorers(topScoreNames, topScore);
                }
            }
        }

        public static void outputTopScorers(List<string> topScores, int topScore)
        {
            topScores.Sort();

            foreach(var i in topScores)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Score: {topScore}");
        }
    }
}
