using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2171
{
    public class Solution2171 : Interface2171
    {
        /// <summary>
        /// 排序 + 前缀和
        /// 如何暴力解呢？
        ///     任选一个元素当作是最后每个非空保留的个数（k个），那么比这个元素小的就需要全部清空，比这个元素大的就需要取出部分，让其剩余k个
        /// 所以可以这样解：
        /// 1. 数组排序
        /// 2. 预处理排序后数组的前缀和
        /// 3. 逐项分析
        /// 示例
        /// 数组：  [4, 1,  6,  5]
        /// 排序：  [1, 4,  5,  6]
        /// 前缀和：[1, 5, 10, 16]
        /// 以1为基准，需要清空的有0个， 需要降为1的有(16-1) -1*3 = 12，共12
        /// 以4为基准，需要清空的有1个， 需要降为4的有(16-5) -4*2 = 3， 共4
        /// 以5为基准，需要清空的有5个， 需要降为5的有(16-10)-5*1 = 1， 共6
        /// 以6为基准，需要清空的有10个，需要降为0的有0，               共10
        /// 需要注意，如果有相等的元素，只需要分析一个就可以了，其实分析了多个也无所谓，
        /// 因为只有第一个相等元素的分析结果是对的，其它的会偏大，不影响最终结果
        /// </summary>
        /// <param name="beans"></param>
        /// <returns></returns>
        public long MinimumRemoval(int[] beans)
        {
            if (beans.Length == 1) return 0;

            int len = beans.Length;
            Array.Sort(beans);
            long[] lsums = new long[len]; lsums[0] = beans[0];
            for (int i = 1; i < len; i++) lsums[i] = lsums[i - 1] + beans[i];

            long result = lsums[^1];
            result = Math.Min(result, lsums[^1] - lsums[0] - (long)beans[0] * (len - 1));  // 以第0项为基准
            for (int i = 1; i < len; i++)                                                  // 以第i项为基准
            {
                if (beans[i] == beans[i - 1]) continue;                                    // 可以考虑使用二分法跳到下一项
                result = Math.Min(result, lsums[i - 1] + (lsums[^1] - lsums[i] - (long)beans[i] * (len - 1 - i)));
            }

            return result;
        }

        /// <summary>
        /// 与MinimumRemoval()逻辑一样，只是遍历过程中增加了二分法跳过相同的项
        /// </summary>
        /// <param name="beans"></param>
        /// <returns></returns>
        public long MinimumRemoval2(int[] beans)
        {
            if (beans.Length == 1) return 0;

            int len = beans.Length;
            Array.Sort(beans);
            long[] lsums = new long[len]; lsums[0] = beans[0];
            for (int i = 1; i < len; i++) lsums[i] = lsums[i - 1] + beans[i];

            long result = lsums[^1];
            result = Math.Min(result, lsums[^1] - lsums[0] - (long)beans[0] * (len - 1));  // 以第0项为基准
            int ptr = 0;
            while (ptr < len)
            {
                ptr = BinarySearch(beans, beans[ptr], ptr + 1);
                if (ptr == -1) break;
                result = Math.Min(result, lsums[ptr - 1] + (lsums[^1] - lsums[ptr] - (long)beans[ptr] * (len - 1 - ptr)));
            }

            return result;
        }

        private int BinarySearch(int[] arr, int target, int index)
        {
            int result = -1, left = index, right = arr.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (arr[mid] > target)
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

        /// <summary>
        /// 与MinimumRemoval()逻辑一样，只是遍历过程中在计算前缀和时，提前预处理了比当前项大的下一项的索引
        /// </summary>
        /// <param name="beans"></param>
        /// <returns></returns>
        public long MinimumRemoval3(int[] beans)
        {
            if (beans.Length == 1) return 0;

            int len = beans.Length;
            Array.Sort(beans);
            long[] lsums = new long[len]; lsums[0] = beans[0];
            List<int> next = new List<int>() { 0 };
            for (int i = 1; i < len; i++)
            {
                lsums[i] = lsums[i - 1] + beans[i];
                if (beans[i] > beans[next[^1]]) next.Add(i);
            }

            long result = lsums[^1];
            result = Math.Min(result, lsums[^1] - lsums[0] - (long)beans[0] * (len - 1));  // 以第0项为基准
            for (int i = 1, j; i < next.Count; i++)                                        // 以第j项为基准
            {
                j = next[i];
                result = Math.Min(result, lsums[j - 1] + (lsums[^1] - lsums[j] - (long)beans[j] * (len - 1 - j)));
            }

            return result;
        }
    }
}
