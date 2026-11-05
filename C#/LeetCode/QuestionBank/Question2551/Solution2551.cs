using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2551
{
    public class Solution2551 : Interface2551
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 
        /// 逻辑应该没问题，但是TLE，看测试用例04的数据量，栈溢出了
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long PutMarbles(int[] weights, int k)
        {
            if (k >= weights.Length || k == 1) return 0;

            Dictionary<(int, int), long> memory = new Dictionary<(int, int), long>();
            long max = dfs(weights, 0, k, memory, (x, y) => Math.Max(x, y), long.MinValue);
            memory.Clear();
            long min = dfs(weights, 0, k, memory, (x, y) => Math.Min(x, y), long.MaxValue);
            return max - min;

            static long dfs(int[] weights, int start, int k, Dictionary<(int, int), long> memory, Func<long, long, long> func, long func_init)
            {
                if (memory.ContainsKey((start, k))) return memory[(start, k)];
                if (k == 1) return weights[start] + weights[^1];

                long result = func_init, _result;
                int end = weights.Length - k + 1;
                for (int i = start; i < end; i++)
                {
                    _result = weights[start] + weights[i] + dfs(weights, i + 1, k - 1, memory, func, func_init);
                    result = func(result, _result);
                }
                memory.Add((start, k), result);
                return result;
            }
        }
    }
}
