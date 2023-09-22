using System;
using System.IO;
using System.Linq;

namespace SpreadSheetReader
{
    class SpreadSheet
    {
        public List<string[]> Sheet;

        public string[] GetColumn(int colNum)
        {
            return Sheet[colNum];
        }

        public string[] GetRow (int rowNum)
        {
            List<string> strings = new List<string>();
            foreach(var i in Sheet)
            {
                try
                {
                    strings.Add(i[rowNum]);
                }
                catch 
                {
                    strings.Add(string.Empty);
                }
            }
            return strings.ToArray();
        }

        public SpreadSheet(string directory)
        {
            Sheet = new List<string[]>();
            string line;
            try
            {
                StreamReader sr = new StreamReader(directory);
                line = sr.ReadLine();
                string[] row;
                while (line != null)
                {
                    row = line.Split(',');
                    Sheet.Add(row);
                    line = sr.ReadLine();
                }

                sr.Close();

            }
            catch(Exception e) { Console.WriteLine("Exception: " + e.Message); }
        }
    }

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

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            for (int i = 0; i < 10000; i++)
            {
                SpreadSheet sheet = new SpreadSheet(Directory);
                if (sheet.Sheet.Count > 0)
                {
                    getHighestScore(sheet);
                }
            }

            watch.Stop();

            Console.WriteLine(watch.Elapsed/10000);
        }

        public static void getHighestScore(SpreadSheet sheet)
        {
            int scoreIndex = -1;

            for(int i = 0; i < sheet.Sheet[0].Length; i++)
            {
                if (sheet.Sheet[0][i] == "Score")
                {
                    scoreIndex = i;
                    break;
                }
            }

            if (scoreIndex == -1) { return; }

            int topScore = -1;

            List<string> topScoreNames = new List<string> {};

            foreach(var i in sheet.Sheet)
            {
                int currentScore;
                if (int.TryParse(i[scoreIndex], out currentScore))
                {
                    if (currentScore > topScore)
                    {
                        topScoreNames = new List<string> { $"{i[0]} {i[1]}" };
                        topScore = currentScore;
                    }
                    else if (currentScore == topScore) 
                    {
                        topScoreNames.Add($"{i[0]} {i[1]}");
                    }
                }
            }

            if (topScoreNames.Count > 0) 
            {
                //outputTopScorers(topScoreNames, topScore);
            }
        }

        public static void outputTopScorers(List<string> topScoreNames, int topScore)
        {
            foreach(var i in topScoreNames)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Score: {topScore}");
        }
    }
}
