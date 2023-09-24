
namespace SpreadSheetReader
{
    class SpreadSheet
    {
        public List<string[]> Sheet;

        //Finds the given column where a certain value exists and then
        //returns true or false based on if it found it and uses out
        //to pass back the index of said value.
        public bool findRow(string field, out int scoreIndex)
        {
            for (int i = 0; i < Sheet[0].Length; i++)
            {
                if (Sheet[0][i] == field)
                {
                    scoreIndex = i;
                    return true;
                }
            }
            scoreIndex = -1;
            return false;
        }

        //
        public List<int> getMax(int index, out int topScore)
        {
            topScore = -1;

            List<int> topScoreIndexs = new List<int> { };

            for (int i = 0; i < Sheet.Count; i++)
            {
                int currentScore;
                if (int.TryParse(Sheet[i][index], out currentScore))
                {
                    if (currentScore > topScore)
                    {
                        topScoreIndexs = new List<int> { i };
                        topScore = currentScore;
                    }
                    else if (currentScore == topScore)
                    {
                        topScoreIndexs.Add(i);
                    }
                }
            }

            return topScoreIndexs;
        }

        //The GetColumn and GetRow aren't used in this program however can
        //be used to get any given row or column for some other application.
        public string[] GetColumn(int colNum)
        {
            return Sheet[colNum];
        }

        public string[] GetRow(int rowNum)
        {
            List<string> strings = new List<string>();
            foreach (var i in Sheet)
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

        //This is the object constructor for the spreadsheet class which takes
        //a directory (Which should corespond to a file) and then will read
        //each line of that file and split each line up using the , character
        //and then add each of them to a list. This list will function as a 2D
        //array which functions similar to a spreadsheet.
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
            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        }
    }
}
