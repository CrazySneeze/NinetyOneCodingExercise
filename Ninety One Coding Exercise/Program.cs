

namespace SpreadSheetReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //First check if there is an argument given when running the program.
            //If there is we set the directory equal to the argument and if not we
            //prompt the user for an input.
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

            //A new spreadsheet is instantiated and once the instantiation is complete
            //we check if the size of the sheet is greater than 0 we can move on to
            //getting the high score
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

            //Find the row that the score is in. This could be hardcoded as in the example
            //we know that the scores will all be in the third row however to ensure the
            //potential for thsi program to be expanded on further a generic function to
            //work out the index of a certain field is necessary
            if (sheet.findRow("Score", out scoreIndex)) 
            { 
                //Now find the maximum value within the sheet and use out to get both a
                //list of the index's for the values as well as the max value found.
                //This out value isn't necessary however makes the code more readable.
                List<int> topScoresIndex = sheet.getMax(scoreIndex, out topScore);
                if (topScoresIndex.Count > 0)
                {
                    List<string> topScoreNames = new List<string>();
                    //Iterate through all of the values in the topScoresIndex and then
                    //format them into a string, adding that string into a list.
                    foreach (int i in topScoresIndex)
                    {
                        topScoreNames.Add($"{sheet.Sheet[i][0]} {sheet.Sheet[i][1]}");
                    }
                    outputTopScorers(topScoreNames, topScore);
                }
            }
        }

        //Iterates through a given list of strings and will output each on a new
        //line and then write the top score int.
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
