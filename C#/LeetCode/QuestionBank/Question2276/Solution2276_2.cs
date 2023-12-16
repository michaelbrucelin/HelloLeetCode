using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2276
{
    public class Solution2276_2
    {
    }

    /// <summary>
    /// 模拟
    /// 本质上与CountIntervals()逻辑一样，但是Add()使用二分法计算合并哪些数组以及插入的位置，O(log n)
    /// 时间复杂度：Add() O(log n), Count() O(1)
    /// </summary>
    public class CountIntervals2 : Interface2276
    {
        public CountIntervals2()
        {
            intervals = new List<(int left, int right)>() { (0, 0), (1000000001, 1000000001) };
            count = 0;
        }

        private List<(int left, int right)> intervals;
        private int count;

        public void Add(int left, int right)
        {
            int cnt = intervals.Count;
            int l = 0, r = cnt - 1;
            // while (l < cnt && intervals[l].right < left) l++;
            int low = 0, high = cnt - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (intervals[mid].right < left)
                {
                    l = mid + 1; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            // while (r >= 0 && intervals[r].left > right) r--;
            low = 0; high = cnt - 1; ;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (intervals[mid].left > right)
                {
                    r = mid - 1; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

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
