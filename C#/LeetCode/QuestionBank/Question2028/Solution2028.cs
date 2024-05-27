using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2028
{
    public class Solution2028 : Interface2028
    {
        /// <summary>
        /// 数学构造
        /// </summary>
        /// <param name="rolls"></param>
        /// <param name="mean"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] MissingRolls(int[] rolls, int mean, int n)
        {
            int sum = mean * (rolls.Length + n) - rolls.Sum();
            if (sum < n || sum > n * 6) return [];

            int[] result = new int[n];
            int x = sum / n, y = sum % n;
            for (int i = 0; i < y; i++) result[i] = x + 1;
            for (int i = y; i < n; i++) result[i] = x;

            return result;
        }
    }
}
