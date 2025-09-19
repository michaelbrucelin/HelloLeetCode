using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3484
{
    public class Solution3484_2
    {
    }

    /// <summary>
    /// 数组
    /// </summary>
    public class Spreadsheet_2 : Interface3484
    {
        public Spreadsheet_2(int rows)
        {
            sheet = new int[rows + 1, 27];
        }

        private int[,] sheet;

        public int GetValue(string formula)
        {
            string[] cells = formula[1..].Split('+');
            return ParseValue(cells[0]) + ParseValue(cells[1]);
        }

        public void ResetCell(string cell)
        {
            (int r, int c) = ParsePos(cell);
            sheet[r, c] = 0;
        }

        public void SetCell(string cell, int value)
        {
            (int r, int c) = ParsePos(cell);
            sheet[r, c] = value;
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
                return sheet[r, c];
            }
            else
            {
                return int.Parse(cell);
            }
        }
    }
}
