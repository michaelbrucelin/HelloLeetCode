using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1000
{
    public class Solution1000 : Interface1000
    {
        /// <summary>
        /// 暴力
        /// 练习一下回溯，DFS
        /// 逻辑没发现问题，提交会超时，参考测试用例05
        /// </summary>
        /// <param name="stones"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MergeStones(int[] stones, int k)
        {
            int len = stones.Length;
            if (len == 1) return 0;
            if ((len - 1) % (k - 1) != 0) return -1;

            int result = int.MaxValue;
            dfs(stones, k, 0, ref result);

            return result;
        }

        private void dfs(int[] stones, int k, int sum, ref int min)
        {
            if (stones.Length == 1) min = Math.Min(min, sum);
            int len = stones.Length;
            for (int i = 0, _len = len - k + 1, _sum; i <= len - k; i++)
            {
                int[] _stones = new int[_len];
                for (int j = 0; j < i; j++) _stones[j] = stones[j];
                _sum = stones[i..(i + k)].Sum(); _stones[i] = _sum;
                for (int j = i + 1; j < _len; j++) _stones[j] = stones[j + k - 1];
                dfs(_stones, k, sum + _sum, ref min);
            }
        }
    }
}
