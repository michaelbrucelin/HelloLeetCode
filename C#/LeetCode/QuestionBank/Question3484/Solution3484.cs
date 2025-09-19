using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3484
{
    public class Solution3484
    {
    }

    /// <summary>
    /// Hash
    /// </summary>
    public class Spreadsheet : Interface3484
    {
        public Spreadsheet(int rows)
        {
            sheet = new Dictionary<int, int[]>();
        }

        private Dictionary<int, int[]> sheet;

        public int GetValue(string formula)
        {
            string[] cells = formula[1..].Split('+');
            return ParseValue(cells[0]) + ParseValue(cells[1]);
        }

        public void ResetCell(string cell)
        {
            (int r, int c) = ParsePos(cell);
            // if (sheet.ContainsKey(r)) sheet[r][c] = 0;
            if (sheet.TryGetValue(r, out int[] value)) value[c] = 0;
        }

        public void SetCell(string cell, int value)
        {
            (int r, int c) = ParsePos(cell);
            if (!sheet.ContainsKey(r)) sheet.Add(r, new int[27]);
            sheet[r][c] = value;
        }

        private (int r, int c) ParsePos(string cell)
        {
            return (int.Parse(cell[1..]), cell[0] & 31);
        }

        private int ParseValue(string cell)
        {
            if (cell[0] > 64)
            {
                (int r, int c) = ParsePos(cell);
                // if (sheet.ContainsKey(r)) return sheet[r][c]; else return 0;
                if (sheet.TryGetValue(r, out int[] value)) return value[c]; else return 0;
            }
            else
            {
                return int.Parse(cell);
            }
        }
    }
}
