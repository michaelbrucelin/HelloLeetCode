using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3144
{
    public class Solution3144_3 : Interface3144
    {
        /// <summary>
        /// 递归 + 贪心
        /// 逻辑同Solution3144，但是这里增加了贪心，这样可以剪枝
        /// 逻辑没问题，依然TLE，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumSubstringsInPartition(string s)
        {
            if (s.Length == 0) return 0;
            if (s.Length <= 2) return 1;

            int result = s.Length, len = s.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) freq[s[i] - 'a']++;
            if (freq.Where(x => x != 0).Distinct().Count() == 1) return 1;
            for (int i = len - 1; i > 0; i--)
            {
                freq[s[i] - 'a']--;
                if (freq.Where(x => x != 0).Distinct().Count() == 1)
                {
                    int _result = MinimumSubstringsInPartition(s[i..]);
                    if (_result == 1) return _result + 1;
                    result = Math.Min(result, 1 + _result);
                }
            }

            return result;
        }
    }
}
