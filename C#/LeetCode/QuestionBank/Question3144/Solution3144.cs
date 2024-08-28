using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3144
{
    public class Solution3144 : Interface3144
    {
        /// <summary>
        /// 递归
        /// 不确定是否会TLE，写出来试试
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumSubstringsInPartition(string s)
        {
            if (s.Length == 0) return 0;
            if (s.Length <= 2) return 1;

            int result = s.Length, len = s.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++)
            {
                freq[s[i] - 'a']++;
                if (freq.Where(x => x != 0).Distinct().Count() == 1)
                    result = Math.Min(result, 1 + MinimumSubstringsInPartition(s[(i + 1)..]));
            }

            return result;
        }
    }
}
