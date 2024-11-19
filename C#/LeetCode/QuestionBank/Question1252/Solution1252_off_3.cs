using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1252
{
    public class Solution1252_off_3 : Interface1252
    {
        /// <summary>
        /// 参照Solution1252_off_3.png就容易理解了
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public int OddCells(int m, int n, int[][] indices)
        {
            int[] rows = new int[m], cols = new int[n];
            for (int i = 0; i < indices.Length; i++)
            {
                rows[indices[i][0]]++; cols[indices[i][1]]++;
            }
            int oddr = 0, oddc = 0;
            for (int i = 0; i < m; i++) oddr += rows[i] & 1;
            for (int i = 0; i < n; i++) oddc += cols[i] & 1;

            return oddr * (n - oddc) + oddc * (m - oddr);
        }
    }
}
