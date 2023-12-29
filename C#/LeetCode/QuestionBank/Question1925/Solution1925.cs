using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1925
{
    public class Solution1925 : Interface1925
    {
        /// <summary>
        /// hash表
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountTriples(int n)
        {
            int[] square = new int[n];
            for (int i = 1; i <= n; i++) square[i - 1] = i * i;
            HashSet<int> set = new HashSet<int>(square);

            int result = 0;
            for (int i = 0; i < n - 2; i++) for (int j = i + 1; j < n - 1; j++)
                {
                    if (set.Contains(square[i] + square[j])) result += 2;
                }

            return result;
        }
    }
}
