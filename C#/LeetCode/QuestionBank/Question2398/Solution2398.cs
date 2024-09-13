using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2398
{
    public class Solution2398 : Interface2398
    {
        /// <summary>
        /// 线段树 + 前缀和 + 双指针
        /// 1. 线段树用来计算任意子数组的最大值
        /// 2. 前缀和用来计算任意子数组的和
        /// 3. 双指针用来实现滑动窗口找结果
        /// </summary>
        /// <param name="chargeTimes"></param>
        /// <param name="runningCosts"></param>
        /// <param name="budget"></param>
        /// <returns></returns>
        public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
        {
            int len = chargeTimes.Length;
            SegmentTree<int> times = new SegmentTree<int>(chargeTimes, Math.Max);
            long[] costs = new long[len + 1];
            for (int i = 0; i < len; i++) costs[i + 1] = costs[i] + runningCosts[i];

            int result = 0, pl = -1, pr = 0;
            while (++pl < len)
            {
                pr = Math.Max(pr, pl);
                while (pr < len && times.Query(pl, pr) + (pr - pl + 1) * (costs[pr + 1] - costs[pl]) <= budget) pr++;
                result = Math.Max(result, pr - pl);
            }

            return result;
        }

        public class SegmentTree<T>
        {
            public SegmentTree(T[] nums, Func<T, T, T> mergeFunction)
            {
                this.nums = nums;
                this.mergeFunc = mergeFunction;
                int len = nums.Length;
                int height = (int)Math.Ceiling(Math.Log(len, 2));
                int maxSize = (1 << (height + 1)) - 1;
                tree = new T[maxSize];
                BuildTree(0, 0, len - 1);
            }

            private T[] nums;
            private T[] tree;
            private Func<T, T, T> mergeFunc;

            private void BuildTree(int index, int start, int end)
            {
                if (start == end)
                {
                    tree[index] = nums[start];
                }
                else
                {
                    int mid = start + ((end - start) >> 1);
                    BuildTree(2 * index + 1, start, mid);
                    BuildTree(2 * index + 2, mid + 1, end);
                    tree[index] = mergeFunc(tree[2 * index + 1], tree[2 * index + 2]);
                }
            }

            public T Query(int start, int end)
            {
                return QueryHelper(0, 0, nums.Length - 1, start, end);
            }

            private T QueryHelper(int index, int start, int end, int qStart, int qEnd)
            {
                if (qStart > end || qEnd < start) return default(T);
                if (qStart <= start && qEnd >= end) return tree[index];

                int mid = start + ((end - start) >> 1);
                T leftResult = QueryHelper(2 * index + 1, start, mid, qStart, qEnd);
                T rightResult = QueryHelper(2 * index + 2, mid + 1, end, qStart, qEnd);
                if (EqualityComparer<T>.Default.Equals(leftResult, default(T))) return rightResult;
                if (EqualityComparer<T>.Default.Equals(rightResult, default(T))) return leftResult;

                return mergeFunc(leftResult, rightResult);
            }
        }
    }
}
