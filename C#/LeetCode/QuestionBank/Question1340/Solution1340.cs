using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1340
{
    public class Solution1340 : Interface1340
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int MaxJumps(int[] arr, int d)
        {
            int len = arr.Length;
            int[] memory = new int[len];
            Array.Fill(memory, -1);
            for (int i = 0; i < len; i++) dfs(i);

            return memory.Max();

            int dfs(int idx)
            {
                if (memory[idx] != -1) return memory[idx];

                int cnt = 0;
                for (int x = 1; x <= d && idx - x >= 0 && arr[idx - x] < arr[idx]; x++) cnt = Math.Max(cnt, dfs(idx - x));
                for (int x = 1; x <= d && idx + x < len && arr[idx + x] < arr[idx]; x++) cnt = Math.Max(cnt, dfs(idx + x));
                memory[idx] = ++cnt;
                return cnt;
            }
        }
    }
}
