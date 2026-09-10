using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0740
{
    public class Solution0740 : Interface0740
    {
        /// <summary>
        /// 排序 + DP
        /// 将Solution0740中的隔位获取值改为DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DeleteAndEarn(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0, num, len = nums.Length; i < len; i++)
            {
                if (map.TryGetValue(num = nums[i], out int sum)) map[num] = sum + num; else map.Add(num, num);
            }
            int idx = 0, cnt = map.Count;
            KeyValuePair<int, int>[] arr = new KeyValuePair<int, int>[cnt];
            foreach (KeyValuePair<int, int> kv in map) arr[idx++] = kv;
            Array.Sort(arr, (x, y) => x.Key - y.Key);

            int[,] dp = new int[cnt, 2];
            dp[0, 1] = arr[0].Value;
            for (int i = 1; i < cnt; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                if (arr[i].Key != arr[i - 1].Key + 1)
                {
                    dp[i, 1] = dp[i, 0] + arr[i].Value;
                }
                else
                {
                    dp[i, 1] = dp[i - 1, 0] + arr[i].Value;
                }
            }
            return Math.Max(dp[cnt - 1, 0], dp[cnt - 1, 1]);
        }
    }
}
