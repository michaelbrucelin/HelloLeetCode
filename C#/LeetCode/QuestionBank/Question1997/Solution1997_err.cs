using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1997
{
    public class Solution1997_err : Interface1997
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 1. 奇数次访问，原地不动或后退
        /// 2. 偶数次访问，前进1步
        /// 
        /// 错误的，因为同样的(odd, from, to)，其它房间的访问奇偶次数也不一定是一样的
        /// </summary>
        /// <param name="nextVisit"></param>
        /// <returns></returns>
        public int FirstDayBeenInAllRooms(int[] nextVisit)
        {
            const int MOD = (int)1e9 + 7;
            int len = nextVisit.Length;
            bool[] freq = new bool[len];  // false even, true odd
            Dictionary<(bool odd, int from, int to), int> memory = new Dictionary<(bool odd, int from, int to), int>
            {
                { (true, len - 1, len - 1), 0 },{ (false, len - 1, len - 1), 0 }
            };

            return dfs(0, len - 1, nextVisit, freq, memory, MOD);
        }

        private int dfs(int from, int to, int[] nextVisit, bool[] freq, Dictionary<(bool odd, int from, int to), int> memory, int MOD)
        {
            bool odd = freq[from] = !freq[from];
            if (memory.ContainsKey((odd, from, to))) return memory[(odd, from, to)];

            try
            {
                if (odd)
                    memory.Add((odd, from, to), dfs(nextVisit[from], to, nextVisit, freq, memory, MOD) + 1);
                else
                    memory.Add((odd, from, to), dfs(from + 1, to, nextVisit, freq, memory, MOD) + 1);
            }
            catch { }

            memory[(odd, from, to)] %= MOD;
            return memory[(odd, from, to)];
        }
    }
}
