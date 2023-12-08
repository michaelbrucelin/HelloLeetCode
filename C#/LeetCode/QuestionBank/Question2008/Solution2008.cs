using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2008
{
    public class Solution2008 : Interface2008
    {
        /// <summary>
        /// DP
        /// 1. rides排序，start_i升序 -> end_i升序 -> end_i-start_i+trip_i降序
        /// 2. 如果 start_j <= start_i && end_j >= start_i && trip_j <= trip_i，即 rides_j 区间更大，路程费+小费更少，就移除 rides_j
        /// 从后向前遍历每一组客人，DP
        /// 1. int[,] dp = new int[m,2], 记录每一个客人“拉”与“不拉”的最大值
        ///     拉客
        ///         二分找到后面第一组没有覆盖关系的客人，客人X
        ///         值 = Max(拉客人X的值, 不拉客人X的值) + 拉这一组客人的值
        ///     不拉客
        ///         值 = Max(拉下一组客的值, 不拉下一组客人的值)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rides"></param>
        /// <returns></returns>
        public long MaxTaxiEarnings(int n, int[][] rides)
        {
            if (rides.Length == 1) return rides[0][1] - rides[0][0] + rides[0][2];

            for (int i = 0; i < rides.Length; i++) rides[i][2] += rides[i][1] - rides[i][0];
            Comparer<int[]> comparer = Comparer<int[]>.Create((a1, a2) => a1[0] != a2[0] ? a1[0] - a2[0] : (a1[1] != a2[1] ? a1[1] - a2[1] : a2[2] - a1[2]));
            Array.Sort(rides, comparer);

            List<(int start, int end, int fee)> info = new List<(int start, int end, int fee)>() { (0, 1, 0), (rides[0][0], rides[0][1], rides[0][2]) };
            int[] _arr1, _arr2;
            for (int i = 1; i < rides.Length; i++)
            {
                _arr1 = rides[i - 1]; _arr2 = rides[i];
                if (_arr2[0] > _arr1[0] || _arr2[2] > _arr1[2]) info.Add((_arr2[0], _arr2[1], _arr2[2]));  // !(范围更大 && 利润更少)
            }
            if (info.Count == 2) return info[1].fee;

            int len = info.Count;
            long[,] dp = new long[len, 2];        // dp[i,0] 不拉客, dp[i,1] 拉客
            dp[len - 1, 1] = info[len - 1].fee;
            for (int i = len - 2, j; i > 0; i--)
            {
                dp[i, 0] = Math.Max(dp[i + 1, 0], dp[i + 1, 1]);
                j = BinarySearch(info, i + 1, info[i].end);
                dp[i, 1] = info[i].fee + (j != -1 ? Math.Max(dp[j, 0], dp[j, 1]) : 0);
            }

            return Math.Max(dp[1, 0], dp[1, 1]);
        }

        private int BinarySearch(List<(int start, int end, int fee)> info, int start, int target)
        {
            int result = -1, left = start, right = info.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (info[mid].start >= target)
                {
                    result = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
