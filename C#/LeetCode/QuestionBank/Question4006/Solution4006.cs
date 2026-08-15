using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4006
{
    public class Solution4006 : Interface4006
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountValidPrefixes(string s)
        {
            int result = 0, len = s.Length;
            int[] cnts = [0, 0];
            for (int i = 0; i < len; i++)
            {
                cnts[s[i] - '0']++;
                if (Math.Abs(cnts[0] - cnts[1]) <= 1) result++;
            }

            return result;
        }
    }
}
