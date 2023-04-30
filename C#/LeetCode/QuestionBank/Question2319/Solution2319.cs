using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2319
{
    public class Solution2319 : Interface2319
    {
        public bool CheckXMatrix(int[][] grid)
        {
            int n = grid.Length - 1;
            for (int i = 0; i <= n; i++) for (int j = 0; j <= n; j++)
                {
                    if (j == i || j == n - i)  // 对角线
                    {
                        if (grid[i][j] == 0) return false;
                    }
                    else
                    {
                        if (grid[i][j] != 0) return false;
                    }
                }

            return true;
        }

        /// <summary>
        /// 使用API做一下
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool CheckXMatrix2(int[][] grid)
        {
            int n = grid.Length - 1;
            return grid.Select((row, rid) => (row, rid))
                       .SelectMany(item => item.row.Select((val, cid) => (val, cid)), (item, element) => (element.val, item.rid, element.cid))
                       .All(point => ((point.rid == point.cid || point.rid + point.cid == n) && point.val != 0) ||
                                     ((point.rid != point.cid && point.rid + point.cid != n) && point.val == 0));
        }
    }
}
