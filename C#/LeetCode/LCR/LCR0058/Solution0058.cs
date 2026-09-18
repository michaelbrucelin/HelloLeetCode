using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0058
{
    public class Solution005
    {
    }

    /// <summary>
    /// 模拟，二分
    /// </summary>
    public class MyCalendar : Interface0058
    {
        public MyCalendar()
        {
            list = [(-1, -1)];
        }

        private List<(int, int)> list;

        public bool Book(int start, int end)
        {
            int id = 0, lo = 0, hi = list.Count - 1, mid;
            while (lo <= hi)
            {
                mid = lo + ((hi - lo) >> 1);
                if (list[mid].Item2 <= start) { id = mid; lo = mid + 1; } else { hi = mid - 1; }
            }

            if (id == list.Count - 1)
            {
                list.Add((start, end));
                return true;
            }
            else if (end <= list[id + 1].Item1)
            {
                list.Insert(id + 1, (start, end));
                return true;
            }

            return false;
        }
    }
}
