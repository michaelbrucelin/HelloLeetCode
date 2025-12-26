using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0352
{
    public class Solution0352
    {
    }

    /// <summary>
    /// 模拟
    /// 这里使用List<int[]> intervals，如果“数据量”很大很极端，可以使用跳表，同时兼顾二分查找和删除新增操作
    /// </summary>
    public class SummaryRanges : Interface0352
    {
        public SummaryRanges()
        {
            intervals = new List<int[]>();
        }

        private List<int[]> intervals;

        public void AddNum(int value)
        {
            if (intervals.Count == 0) { intervals.Add([value, value]); return; }

            int id = BinarySearch(value);
            if (id == -1)
            {
                if (value == intervals[0][0] - 1) intervals[0][0] = value; else intervals.Insert(0, [value, value]);
            }
            else
            {
                if (value <= intervals[id][1]) return;
                if (id == intervals.Count - 1)
                {
                    if (value == intervals[id][1] + 1) intervals[id][1] = value; else intervals.Add([value, value]);
                }
                else
                {
                    switch ((value - intervals[id][1], intervals[id + 1][0] - value))
                    {
                        case (1, 1): intervals[id][1] = intervals[id + 1][1]; intervals.RemoveAt(id + 1); break;
                        case (1, _): intervals[id][1] = value; break;
                        case (_, 1): intervals[id + 1][0] = value; break;
                        default: intervals.Insert(id + 1, [value, value]); break;
                    }
                }
            }
        }

        public int[][] GetIntervals()
        {
            return intervals.ToArray();
        }

        private int BinarySearch(int target)
        {
            int result = -1, left = 0, right = intervals.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (intervals[mid][0] <= target)
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
