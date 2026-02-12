using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0086
{
    public class Solution0086 : Interface0086
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string[][] Partition(string s)
        {
            int len = s.Length;
            byte[,] memory = new byte[len, len];  // 0: null, 1: false, 2: true
            List<string[]> result = [];
            dfs([], 0);

            return [.. result];

            void dfs(List<(int, int)> list, int left)
            {
                if (left == len)
                {
                    int idx = 0, cnt = list.Count;
                    string[] strs = new string[cnt];
                    foreach ((int l, int r) in list) strs[idx++] = s[l..(r + 1)];
                    result.Add(strs);
                    return;
                }

                dfs([.. list, (left, left)], left + 1);
                for (int right = left + 1; right < len; right++)
                {
                    if (memory[left, right] == 0)
                    {
                        memory[left, right] = 2;
                        for (int l = left, r = right; l < r; l++, r--) if (s[l] != s[r]) { memory[left, right] = 1; break; }
                    }

                    if (memory[left, right] == 2) dfs([.. list, (left, right)], right + 1);
                }
            }
        }

        /// <summary>
        /// 逻辑同Partition()，改成回溯
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string[][] Partition2(string s)
        {
            int len = s.Length;
            byte[,] memory = new byte[len, len];  // 0: null, 1: false, 2: true
            List<string[]> result = [];
            List<(int, int)> buffer = [];
            backtrack(0);

            return [.. result];

            void backtrack(int left)
            {
                if (left == len)
                {
                    int idx = 0, cnt = buffer.Count;
                    string[] strs = new string[cnt];
                    foreach ((int l, int r) in buffer) strs[idx++] = s[l..(r + 1)];
                    result.Add(strs);
                    return;
                }

                buffer.Add((left, left));
                backtrack(left + 1);
                buffer.RemoveAt(buffer.Count - 1);

                for (int right = left + 1; right < len; right++)
                {
                    if (memory[left, right] == 0)
                    {
                        memory[left, right] = 2;
                        for (int l = left, r = right; l < r; l++, r--) if (s[l] != s[r]) { memory[left, right] = 1; break; }
                    }

                    if (memory[left, right] == 2)
                    {
                        buffer.Add((left, right));
                        backtrack(right + 1);
                        buffer.RemoveAt(buffer.Count - 1);
                    }
                }
            }
        }
    }
}
