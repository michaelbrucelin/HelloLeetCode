using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0514
{
    public class Solution0514_3 : Interface0514
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution0514_2，由DFS演变过来的DP，Solution0514_2中的DFS本质上就是由底向上的DP
        /// 假定由ring的任意位置（i）拨xxxx的最小值都已知，为dp[i]
        /// 那么由位置j拨yxxxx的最小值就是：由位置j拨每一个y的位置（k）+dp[k] 的最小值
        /// 
        /// 理论上DP的时间复杂度会比DFS+记忆化搜索要大，因为计算了全部的状态，二记忆化搜索至计算了需要的状态
        /// </summary>
        /// <param name="ring"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int FindRotateSteps(string ring, string key)
        {
            int len = ring.Length;
            List<int>[] dist = new List<int>[26];
            for (int i = 0; i < 26; i++) dist[i] = new List<int>();
            for (int i = 0; i < len; i++) dist[ring[i] - 'a'].Add(i);

            int[] dp = new int[len], _dp = new int[len];
            for (int i = key.Length - 1, _step; i >= 0; i--)
            {
                Array.Fill(_dp, 5000);  // 题目的数据范围，结果不会大于5000
                for (int j = 0; j < len; j++) foreach (int id in dist[key[i] - 'a'])
                    {
                        _step = (id - j) switch { > 0 => Math.Min(id - j, len - id + j), < 0 => Math.Min(j - id, len - j + id), _ => 0 };
                        _dp[j] = Math.Min(_dp[j], _step + 1 + dp[id]);
                    }
                Array.Copy(_dp, dp, len);
            }

            return dp[0];
        }
    }
}
