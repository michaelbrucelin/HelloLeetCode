using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2944
{
    public class Solution2944 : Interface2944
    {
        /// <summary>
        /// DP
        /// dp[i]记录购买prices[i]的最小成本
        /// 下面以[26, 18, 6, 12, 49, 7, 45, 45]为例
        /// 1   2   3   4   5   6   7   8
        /// 26  18  6   12  49  7   45  45
        /// 26  44  32  44  81  39  77  91    购买prices[i]的最小成本
        /// 2   4   6   8   10  14  14  16    购买prices[i]的最远距离，距离大于等于8的最小成本是39
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MinimumCoins(int[] prices)
        {
            int n = prices.Length;
            int[] dp = new int[n + 1];
            dp[1] = prices[0];
            for (int i = 2, min; i <= n; i++)
            {
                min = int.MaxValue;
                for (int j = i / 2; j < i; j++) min = Math.Min(min, dp[j]);
                dp[i] = min + prices[i - 1];
            }

            int result = dp[n];
            for (int i = (n + 1) / 2; i < n; i++) result = Math.Min(result, dp[i]);
            return result;
        }

        /// <summary>
        /// 逻辑同MinimumCoins()，使用最小堆加速查找dp[i]左侧的最小值
        /// 
        /// 竟然没有MinimumCoins()快，应该是题目的数据量太小导致的
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MinimumCoins2(int[] prices)
        {
            int n = prices.Length;
            int[] dp = new int[n + 1];
            PriorityQueue<(int cost, int reach), int> minpq = new PriorityQueue<(int cost, int reach), int>();
            dp[1] = prices[0];
            minpq.Enqueue((dp[1], 2), dp[1]);
            (int cost, int reach) item;
            for (int i = 2; i <= n; i++)
            {
                while ((item = minpq.Dequeue()).reach < i - 1) ;
                minpq.Enqueue(item, item.cost);
                dp[i] = item.cost + prices[i - 1];
                minpq.Enqueue((dp[i], i << 1), dp[i]);
            }

            while ((item = minpq.Dequeue()).reach < n) ;
            return item.cost;
        }
    }
}
