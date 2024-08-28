using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3144
{
    public class Solution3144_4 : Interface3144
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// 逻辑同Solution3144_3，逻辑没问题，依然TLE，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumSubstringsInPartition(string s)
        {
            Dictionary<string, int> memory = new Dictionary<string, int>();
            return dfs(s);

            int dfs(string s)
            {
                if (s.Length == 0) return 0;
                if (s.Length <= 2) return 1;
                if (memory.ContainsKey(s)) return memory[s];

                memory.Add(s, s.Length);
                int len = s.Length;
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
                        memory[s] = Math.Min(memory[s], 1 + _result);
                    }
                }

                return memory[s];
            }
        }
    }
}
