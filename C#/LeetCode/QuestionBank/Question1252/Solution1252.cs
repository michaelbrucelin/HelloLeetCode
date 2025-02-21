using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1252
{
    public class Solution1252 : Interface1252
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public int OddCells(int m, int n, int[][] indices)
        {
            int[,] nums = new int[m, n];
            for (int i = 0, r = 0, c = 0; i < indices.Length; i++)
            {
                r = indices[i][0]; c = indices[i][1];
                for (int j = 0; j < n; j++) nums[r, j]++;
                for (int j = 0; j < m; j++) nums[j, c]++;
            }

            int result = 0;
            foreach (int i in nums) result += i & 1;
            return result;
        }

        /// <summary>
        /// 与OddCells()逻辑一样，将整型+1操作，改为bool取反操作
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public int OddCells2(int m, int n, int[][] indices)
        {
            bool[,] mask = new bool[m, n];
            for (int i = 0, r = 0, c = 0; i < indices.Length; i++)
            {
                r = indices[i][0]; c = indices[i][1];
                for (int j = 0; j < n; j++) mask[r, j] = !mask[r, j];
                for (int j = 0; j < m; j++) mask[j, c] = !mask[j, c];
            }

            int result = 0;
            foreach (bool b in mask) result += b ? 1 : 0;
            return result;
        }
    }
}
