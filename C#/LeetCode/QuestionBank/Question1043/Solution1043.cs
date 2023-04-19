using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1043
{
    public class Solution1043 : Interface1043
    {
        /// <summary>
        /// DFS，递归
        /// 1. 第1个元素独立一组 + rec(arr[1..], k)
        /// 2. 前2个元素独立一组 + rec(arr[2..], k)
        ///    ... ...
        /// k. 前k个元素独立一组 + rec(arr[k..], k)
        /// n. 结果是前面k个值中的最大值
        /// 
        /// 优化空间
        /// 1. 总感觉可以贪心解决，但是没想明白怎样贪心
        /// 2. 查询数组某个连续区间的最大值，有高效的算法，这里直接记忆化搜索了
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            if (arr.Length <= k) return arr.Max() * arr.Length;
            Dictionary<(int, int), int> helper = new Dictionary<(int, int), int>();

            return rec(arr, k, 0, helper);
        }

        private int rec(int[] arr, int k, int start, Dictionary<(int, int), int> helper)
        {
            int len = arr.Length;
            if (helper.ContainsKey((start, len))) return helper[(start, len)];

            if (len - start <= k)
            {
                if (!helper.ContainsKey((start, len)))
                    helper.Add((start, len), arr[start..].Max() * (len - start));
            }
            else
            {
                int result = 0;
                for (int cnt = 1; cnt <= k; cnt++)
                {
                    if (!helper.ContainsKey((start, start + cnt)))
                        helper.Add((start, start + cnt), arr[start..(start + cnt)].Max() * cnt);
                    result = Math.Max(result, helper[(start, start + cnt)] + rec(arr, k, start + cnt, helper));
                }
                helper.Add((start, len), result);
            }

            return helper[(start, len)];
        }
    }
}
