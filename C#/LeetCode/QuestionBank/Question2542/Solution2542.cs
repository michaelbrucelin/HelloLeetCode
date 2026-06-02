using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2542
{
    public class Solution2542 : Interface2542
    {
        /// <summary>
        /// 排序 + 小顶堆
        /// 枚举“最小值”显然比枚举子序列要简单得多，所以沿着这个思路继续往下想
        /// 1. nums2排序，nums1随着nums2排序
        /// 2. 假定nums2[i]是子序列的最小值，显然子序列余下的k-1个值一定需要从下标i后边选择
        ///     显然问题变成了top(k)问题了，即从nums1[(i+1)..]中选出最大的k-1个值求和
        ///     所以使用小顶堆来优化这个过程
        /// 3. 综上1+2，从后向前遍历即可
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxScore(int[] nums1, int[] nums2, int k)
        {
            long result; int len = nums1.Length;
            if (k == 1)
            {
                result = 1L * nums1[0] * nums2[0];
                for (int i = 1; i < len; i++) result = Math.Max(result, 1L * nums1[i] * nums2[i]);
                return result;
            }

            int[] order = new int[len];
            for (int i = 0; i < len; i++) order[i] = i;
            Array.Sort(order, (x, y) => nums2[x] - nums2[y]);
            sort();

            long sum = 0;
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            for (int i = len - k + 1; i < len; i++) { sum += nums1[i]; minpq.Enqueue(nums1[i], nums1[i]); }
            result = 1L * nums2[len - k] * (sum + nums1[len - k]);
            for (int i = len - k - 1; i >= 0; i--)
            {
                if (nums1[i + 1] > minpq.Peek())
                {
                    sum -= minpq.Dequeue(); sum += nums1[i + 1]; minpq.Enqueue(nums1[i + 1], nums1[i + 1]);
                }
                result = Math.Max(result, 1L * nums2[i] * (sum + nums1[i]));
            }

            return result;

            void sort()
            {
                int[] _nums1 = new int[len], _nums2 = new int[len];
                for (int i = 0; i < len; i++)
                {
                    _nums1[i] = nums1[order[i]];
                    _nums2[i] = nums2[order[i]];
                }
                nums1 = _nums1; nums2 = _nums2;
            }
        }

        /// <summary>
        /// 逻辑同MaxScore()，内部的sort()换了个写法玩玩
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxScore2(int[] nums1, int[] nums2, int k)
        {
            long result; int len = nums1.Length;
            if (k == 1)
            {
                result = 1L * nums1[0] * nums2[0];
                for (int i = 1; i < len; i++) result = Math.Max(result, 1L * nums1[i] * nums2[i]);
                return result;
            }

            int[] order = new int[len];
            for (int i = 0; i < len; i++) order[i] = i;
            Array.Sort(order, (x, y) => nums2[x] - nums2[y]);
            sort();

            long sum = 0;
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            for (int i = len - k + 1; i < len; i++) { sum += nums1[i]; minpq.Enqueue(nums1[i], nums1[i]); }
            result = 1L * nums2[len - k] * (sum + nums1[len - k]);
            for (int i = len - k - 1; i >= 0; i--)
            {
                if (nums1[i + 1] > minpq.Peek())
                {
                    sum -= minpq.Dequeue(); sum += nums1[i + 1]; minpq.Enqueue(nums1[i + 1], nums1[i + 1]);
                }
                result = Math.Max(result, 1L * nums2[i] * (sum + nums1[i]));
            }

            return result;

            void sort()
            {
                BitArray bits = new BitArray(len);
                for (int i = 0, j, t1, t2; i < len; i++)
                {
                    if (bits[i] || order[i] == i) continue;
                    t1 = nums1[i]; t2 = nums2[i];
                    j = i;
                    do
                    {
                        nums1[j] = nums1[order[j]]; nums2[j] = nums2[order[j]]; bits[j] = true; j = order[j];
                    } while (order[j] != i);
                    nums1[j] = t1; nums2[j] = t2; bits[j] = true;
                }
            }
        }
    }
}
