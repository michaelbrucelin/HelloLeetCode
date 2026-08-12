using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2767
{
    public class Solution2767 : Interface2767
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumBeautifulSubstrings(string s)
        {
            if (s[0] == '0') return -1;

            HashSet<int> pow5 = new HashSet<int>();
            for (int i = 1; i < 65536; i *= 5) pow5.Add(i);  // 题目限定s.Length < 16
            int[] memory = new int[s.Length];
            for (int i = 0; i < s.Length; i++) memory[i] = s[i] - '0' - 1;

            return dfs(s, 0, memory, pow5);

            static int dfs(string s, int idx, int[] memory, HashSet<int> set)
            {
                if (idx == s.Length) return 0;
                if (memory[idx] != 0) return memory[idx];

                int result = int.MaxValue, _result, x = 0;
                for (int i = idx, len = s.Length; i < len; i++)
                {
                    x = (x << 1) + s[i] - '0';
                    if (set.Contains(x))
                    {
                        _result = dfs(s, i + 1, memory, set);
                        if (_result != -1) result = Math.Min(result, _result + 1);
                    }
                }
                if (result == int.MaxValue) result = -1;

                memory[idx] = result;
                return result;
            }
        }
    }
}
