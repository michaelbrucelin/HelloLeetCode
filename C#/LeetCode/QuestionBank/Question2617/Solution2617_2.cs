using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2617
{
    public class Solution2617_2 : Interface2617
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 
        /// 理论上只能比Solution2617慢，不会快，这里写着玩的，还可以1:1翻译为DP
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumVisitedCells(int[][] grid)
        {
            if (grid.Length == 1 && grid[0].Length == 1) return 1;

            int rcnt = grid.Length, ccnt = grid[0].Length, result = rcnt + ccnt;
            int[,] visited = new int[rcnt,ccnt];

            return result != rcnt + ccnt ? result : -1;
        }
    }
}
