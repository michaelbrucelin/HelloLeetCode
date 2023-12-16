using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2276
{
    public class Solution2276
    {
    }

    /// <summary>
    /// 模拟
    /// 用一个有序的数组保存现有区间
    /// 添加区间时从前向后找合适的位置，合并区间，并计算“整数的数量”
    ///     合并区间可参考图Solution2276.jpg
    /// 时间复杂度：Add() O(n), Count() O(1)
    /// </summary>
    public class CountIntervals : Interface2276
    {
        public CountIntervals()
        {
            intervals = new List<(int left, int right)>() { (0, 0), (1000000001, 1000000001) };
            count = 0;
        }

        private List<(int left, int right)> intervals;
        private int count;

        /*
         * l == r 可以合并到 l < r 分支中
        public void Add(int left, int right)
        {
            int cnt = intervals.Count;
            int l = 0, r = cnt - 1;
            while (l < cnt && intervals[l].right < left) l++;
            while (r >= 0 && intervals[r].left > right) r--;
            if (l < r)
            {
                var interval = (Math.Min(intervals[l].left, left), Math.Max(intervals[r].right, right));
                for (int i = r; i >= l; i--)
                {
                    count -= intervals[i].right - intervals[i].left + 1;
                    intervals.RemoveAt(i);
                }
                count += interval.Item2 - interval.Item1 + 1;
                intervals.Insert(l, interval);
            }
            else if (l > r)
            {
                count += right - left + 1;
                intervals.Insert(l, (left, right));
            }
            else  // l == r
            {
                var interval = (Math.Min(intervals[l].left, left), Math.Max(intervals[r].right, right));
                count -= intervals[l].right - intervals[l].left + 1;
                intervals.RemoveAt(l);
                count += interval.Item2 - interval.Item1 + 1;
                intervals.Insert(l, interval);
            }
        }
        */

        public void Add(int left, int right)
        {
            int cnt = intervals.Count;
            int l = 0, r = cnt - 1;
            while (l < cnt && intervals[l].right < left) l++;
            while (r >= 0 && intervals[r].left > right) r--;
            if (l <= r)
            {
                var interval = (Math.Min(intervals[l].left, left), Math.Max(intervals[r].right, right));
                for (int i = r; i >= l; i--)
                {
                    count -= intervals[i].right - intervals[i].left + 1;
                    intervals.RemoveAt(i);
                }
                count += interval.Item2 - interval.Item1 + 1;
                intervals.Insert(l, interval);
            }
            else
            {
                count += right - left + 1;
                intervals.Insert(l, (left, right));
            }
        }

        public int Count()
        {
            return count;
        }
    }
}
