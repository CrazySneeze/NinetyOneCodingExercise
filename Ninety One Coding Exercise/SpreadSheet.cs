
namespace SpreadSheetReader
{
    class SpreadSheet
    {
        public List<string[]> Sheet;

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
