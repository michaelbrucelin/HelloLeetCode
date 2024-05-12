using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1553
{
    public class Solution1553_2 : Interface1553
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 就是将Solution1553中的递归添加了记忆化搜索
        /// 
        /// 提交出错，超出了CLR允许的最大递归层数，Solution1553_3中将递归改为迭代试试
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinDays(int n)
        {
            if (n < 3) return n;

            int[] memory = new int[n + 1];
            memory[1] = 1;
            memory[2] = 2;
            return dfs(n, memory);
        }

        private int dfs(int n, int[] memory)
        {
            if (memory[n] > 0) return memory[n];

            int rec = dfs(n - 1, memory);
            if ((n & 1) == 0) rec = Math.Min(rec, dfs(n >> 1, memory));
            if ((n % 3) == 0) rec = Math.Min(rec, dfs(n / 3, memory));
            memory[n] = rec + 1;

            return memory[n];
        }
    }
}
