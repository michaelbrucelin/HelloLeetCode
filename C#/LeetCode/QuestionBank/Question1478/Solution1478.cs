using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1478
{
    public class Solution1478 : Interface1478
    {
        /// <summary>
        /// 排序 + dfs + 记忆化搜索
        /// 先将数组排序，然后分为k组，每组选一个位置放邮箱即可，所以可以使用 dfs + 记忆化搜索 来求解
        /// 对于子数组 houses[i..j] 的最优解是什么，有中位数定理这个O(1)解的（需要借助前缀和）
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinDistance(int[] houses, int k)
        {
            Array.Sort(houses);
            int len = houses.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + houses[i];

            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();  // (int start, int k)
            return dfs(0, k);

            int dfs(int start, int k)
            {
                if (len - start == k) return 0;
                if (memory.TryGetValue((start, k), out int value)) return value;

                int result = int.MaxValue;
                if (k == 1)
                {
                    result = mindistance(start, len - 1);
                }
                else
                {
                    result = int.MaxValue;
                    for (int i = start + 1; len - i >= k - 1; i++) result = Math.Min(result, mindistance(start, i - 1) + dfs(i, k - 1));
                }

                memory.Add((start, k), result);
                return result;
            }

            int mindistance(int left, int right)
            {
                int mid = (right - left) >> 1;
                return (sums[right + 1] - sums[right - mid]) - (sums[left + mid + 1] - sums[left]);
            }
        }
    }
}
