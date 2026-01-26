using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3746
{
    public class Solution3746 : Interface3746
    {
        /// <summary>
        /// 脑筋急转弯
        /// 统计a与b的数量即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinLengthAfterRemovals(string s)
        {
            int result = 0;
            foreach (char c in s) result += ((c - 'a') << 1) - 1;

            return result >= 0 ? result : -result;
        }

        public int MinLengthAfterRemovals2(string s)
        {
            int result = -s.Length, len = s.Length;
            for (int i = 0; i < len; i++) result += (s[i] - 'a') << 1;

            return result >= 0 ? result : -result;
        }
    }
}
