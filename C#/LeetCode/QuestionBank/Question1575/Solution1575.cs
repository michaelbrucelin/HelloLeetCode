using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1575
{
    public class Solution1575 : Interface1575
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// </summary>
        /// <param name="locations"></param>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="fuel"></param>
        /// <returns></returns>
        public int CountRoutes(int[] locations, int start, int finish, int fuel)
        {
            int len = locations.Length;
            const int MOD = (int)1e9 + 7;
            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            return dfs(start, fuel);

            int dfs(int curr, int fuel)
            {
                if (memory.ContainsKey((curr, fuel))) return memory[(curr, fuel)];

                int result = curr == finish ? 1 : 0, _fuel;
                for (int i = 0; i < len; i++) if (i != curr && (_fuel = Math.Abs(locations[i] - locations[curr])) <= fuel)
                    {
                        result += dfs(i, fuel - _fuel);
                        result %= MOD;
                    }

                memory[(curr, fuel)] = result;
                return result;
            }
        }
    }
}
