using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1476
{
    public class Solution1476
    {
    }

    /// <summary>
    /// 模拟
    /// 题目的约束，总数据量1W，总操作数500，所以这里只记录操作的过程，不真的操作
    /// </summary>
    public class SubrectangleQueries : Interface1476
    {
        public SubrectangleQueries(int[][] rectangle)
        {
            init = rectangle;
            updates = [];
        }

        private int[][] init;
        private List<(int, int, int, int, int)> updates;

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        {
            updates.Add((row1, row2, col1, col2, newValue));
        }

        public int GetValue(int row, int col)
        {
            for (int i = updates.Count - 1; i >= 0; i--)
            {
                if (row >= updates[i].Item1 && row <= updates[i].Item2 && col >= updates[i].Item3 && col <= updates[i].Item4)
                    return updates[i].Item5;
            }
            return init[row][col];
        }
    }
}
