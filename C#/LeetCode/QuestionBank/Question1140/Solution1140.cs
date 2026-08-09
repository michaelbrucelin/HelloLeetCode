using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1140
{
    public class Solution1140 : Interface1140
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        public int StoneGameII(int[] piles)
        {
            int len = piles.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + piles[i];
            Dictionary<(int, int, bool), (int, int)> memory = new Dictionary<(int, int, bool), (int, int)>();

            return dfs(0, 1, true).Item1;

            (int, int) dfs(int idx, int m, bool isAlice)
            {
                if (memory.ContainsKey((idx, m, isAlice))) return memory[(idx, m, isAlice)];

                int alice = 0, bob = 0, M = m << 1, _alice, _bob;
                if (len - idx <= M)
                {
                    if (isAlice) alice = sums[len] - sums[idx]; else bob = sums[len] - sums[idx];
                }
                else
                {
                    if (isAlice)
                    {
                        for (int i = 1; i <= M; i++)
                        {
                            (_alice, _bob) = dfs(idx + i, Math.Max(m, i), false);
                            if (sums[idx + i] - sums[idx] + _alice > alice)
                            {
                                alice = sums[idx + i] - sums[idx] + _alice; bob = _bob;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= M; i++)
                        {
                            (_alice, _bob) = dfs(idx + i, Math.Max(m, i), true);
                            if (sums[idx + i] - sums[idx] + _bob > bob)
                            {
                                bob = sums[idx + i] - sums[idx] + _bob; alice = _alice;
                            }
                        }
                    }
                }

                memory.Add((idx, m, isAlice), (alice, bob));
                return (alice, bob);
            }
        }
    }
}
