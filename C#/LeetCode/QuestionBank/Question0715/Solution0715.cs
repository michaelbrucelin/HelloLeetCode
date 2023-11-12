using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode.QuestionBank.Question0715
{
    public class Solution0715
    {
    }

    /// <summary>
    /// 1. 已有的[left, right)区间保持没有交集，从小到大排列，当一个新的[left, right)区间出现时
    ///     1. 与任何已有的区间都没有交集
    ///         Add，将其插入的合适的位置即可
    ///         Remove，不需要任何操作
    ///     2. 与当前的1个或多个区间有交集，分析新区间左右端点的位置，不难，这里就是描述了
    ///         核心：找 最左侧/最小的 右端点 >= left  的区间
    ///               找 最右侧/最大的 左端点 <= right 的区间
    /// </summary>
    public class RangeModule : Interface0715
    {
        public RangeModule()
        {
            ranges = new List<(int left, int right)>();
        }

        private List<(int left, int right)> ranges;

        public void AddRange(int left, int right)
        {
            if (ranges.Count == 0 || ranges[^1].right < left)
            {
                ranges.Add((left, right)); return;
            }
            else if (ranges[0].left > right)
            {
                ranges.Insert(0, (left, right)); return;
            }

            int lid = BinarySearchLeft(ranges, left), rid = BinarySearchRight(ranges, right);
            int _left = Math.Min(left, ranges[lid].left);     // 容斥原理
            int _right = Math.Max(right, ranges[rid].right);  // 容斥原理

            for (int i = 0; i < rid - lid + 1; i++) ranges.RemoveAt(lid);
            ranges.Insert(lid, (_left, _right));
        }

        public bool QueryRange(int left, int right)
        {
            if (ranges.Count == 0 || ranges[^1].right < left || ranges[0].left > right) return false;

            int lid = BinarySearchLeft(ranges, left);

            return ranges[lid].left <= left && ranges[lid].right >= right;
        }

        public void RemoveRange(int left, int right)
        {
            if (ranges.Count == 0 || ranges[^1].right < left || ranges[0].left > right) return;

            int lid = BinarySearchLeft(ranges, left), rid = BinarySearchRight(ranges, right);
            if (right < ranges[rid].right) ranges.Insert(rid + 1, (right, ranges[rid].right));  // 容斥原理
            if (left > ranges[lid].left) ranges.Insert(rid + 1, (ranges[lid].left, left));      // 容斥原理

            for (int i = 0; i < rid - lid + 1; i++) ranges.RemoveAt(lid);
        }

        /// <summary>
        /// 找 最左侧/最小的 右端点 >= target 的区间
        /// </summary>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearchLeft(List<(int left, int right)> list, int target)
        {
            int result = list.Count, left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid].right >= target)
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
        /// 找 最右侧/最大的 左端点 <= target 的区间
        /// </summary>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearchRight(List<(int left, int right)> list, int target)
        {
            int result = -1, left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid].left <= target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
