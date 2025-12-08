using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0516
{
    public class Solution0516 : Interface0516
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindromeSubseq(string s)
        {
            if (s.Length == 1) return 1;

            int len = s.Length;
            int[,] memory = new int[len, len];
            for (int i = 0; i < len; i++) for (int j = 0; j < len; j++) memory[i, j] = -1;
            dfs(0, len - 1);

            return memory[0, len - 1];

            int dfs(int l, int r)
            {
                if (l > r) return 0;
                if (memory[l, r] != -1) return memory[l, r];
                if (l == r)
                {
                    memory[l, r] = 1;
                }
                else
                {
                    if (s[l] == s[r])
                    {
                        memory[l, r] = dfs(l + 1, r - 1) + 2;
                    }
                    else
                    {
                        memory[l, r] = Math.Max(dfs(l + 1, r), dfs(l, r - 1));
                    }
                }
                return memory[l, r];
            }
        }
    }
}
