using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0807
{
    public class Solution0807 : Interface0807
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string[] Permutation(string S)
        {
            int n = 1, len = S.Length;
            for (int i = 2; i <= len; i++) n *= i;
            string[] result = new string[n];
            int idx = 0;
            dfs(new char[len], S.ToList());

            return result;

            void dfs(char[] s, List<char> chars)
            {
                if (chars.Count == 0) result[idx++] = new string(s);

                int cnt = chars.Count;
                for (int i = 0; i < cnt; i++)
                {
                    char[] _s = s.ToArray();
                    List<char> _chars = chars.ToList();
                    _s[len - cnt] = _chars[i];
                    _chars.RemoveAt(i);
                    dfs(_s, _chars);
                }
            }
        }

        /// <summary>
        /// 逻辑完全同Permutation()，改为回溯
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string[] Permutation2(string S)
        {
            int n = 1, len = S.Length;
            for (int i = 2; i <= len; i++) n *= i;
            string[] result = new string[n];
            int idx = 0;
            bool[] mask = new bool[len];
            Array.Fill(mask, true);
            char[] s = new char[len];
            backtrack(0);

            return result;

            void backtrack(int p)
            {
                if (p == len) { result[idx++] = new string(s); return; }

                for (int i = 0; i < len; i++) if (mask[i])
                    {
                        s[p] = S[i]; mask[i] = false;
                        backtrack(p + 1);
                        mask[i] = true;
                    }
            }
        }
    }
}
