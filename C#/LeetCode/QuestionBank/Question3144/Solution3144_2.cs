using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3144
{
    public class Solution3144_2 : Interface3144
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 逻辑同Solution3144，尽管增加了记忆化搜索，依然TLE，参考测试用例03
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
                for (int i = 0; i < len; i++)
                {
                    freq[s[i] - 'a']++;
                    if (freq.Where(x => x != 0).Distinct().Count() == 1)
                        memory[s] = Math.Min(memory[s], 1 + MinimumSubstringsInPartition(s[(i + 1)..]));
                }

                return memory[s];
            }
        }
    }
}
