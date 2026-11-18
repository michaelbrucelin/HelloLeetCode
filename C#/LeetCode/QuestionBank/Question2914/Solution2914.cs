using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2914
{
    public class Solution2914 : Interface2914
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinChanges(string s)
        {
            if (s.Length == 0) return 0;

            int result = 0, len = s.Length;
            for (int i = 1; i < len; i += 2) result += Math.Abs(s[i] - s[i - 1]);

            return result;
        }
    }
}
