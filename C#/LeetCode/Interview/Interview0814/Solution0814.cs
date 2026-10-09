using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0814
{
    public class Solution0814 : Interface0814
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 
        /// 没写完，稍后再写
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public int CountEval(string s, int result)
        {
            if ((result >> 1) != 0) return 0;
            if (s.Length == 1) return s[0] - '0' == result ? 1 : 0;

            int len = s.Length;
            int[,] memory = new int[len, 2];
            for (int i = 0; i < len; i++) memory[i, 0] = memory[i, 1] = -1;
            memory[len - 1, s[len - 1] - '0'] = 1;
            memory[len - 1, '0' + 1 - s[len - 1]] = 0;

            throw new NotImplementedException();

            static int dfs(int idx, int target, int[,] memory)
            {
                if (memory[idx, target] != -1) return memory[idx, target];
                int result = 0;


                memory[idx, target] = result;
                return result;
            }
        }
    }
}
