using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1477
{
    public class Solution1477 : Interface1477
    {
        /// <summary>
        /// 维护左枚举右
        /// 从左向右遍历数组
        ///     使用Hash记录下前缀和对应的索引，相同的前缀和记录下最后的索引即可
        ///     使用数组 dp[i,0] 记录以 arr[i] 结尾的和为target的最小子数组的长度
        ///     使用数组 dp[i,1] 记录以 arr[0..i] 中和为target的最小子数组的长度，即子数组不一定以 arr[i] 结尾
        /// 有了上面的数据，就可以计算每一个前缀数组的两个不重叠且和为target的子数组的最小长度了
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinSumOfLengths(int[] arr, int target)
        {
            int result = int.MaxValue, len = arr.Length;
            Dictionary<int, int> map = new Dictionary<int, int>() { { 0, -1 } };
            int[,] dp = new int[len, 2];
            for (int i = 0; i < len; i++) dp[i, 0] = dp[i, 1] = int.MaxValue;
            map.Add(arr[0], 0);
            if (arr[0] == target) dp[0, 0] = dp[0, 1] = 1;
            int sum = arr[0];
            for (int i = 1; i < len; i++)
            {
                sum += arr[i];
                if (!map.TryAdd(sum, i)) map[sum] = i;
                if (map.TryGetValue(sum - target, out int idx)) dp[i, 0] = i - idx;  // 题目限定 target > 0
                dp[i, 1] = Math.Min(dp[i, 0], dp[i - 1, 1]);
                if (dp[i, 0] != int.MaxValue && i - dp[i, 0] > 0 && dp[i - dp[i, 0], 1] != int.MaxValue) result = Math.Min(result, dp[i, 0] + dp[i - dp[i, 0], 1]);
                if (result == 2) return 2;
            }

            return result != int.MaxValue ? result : -1;
        }
    }
}
