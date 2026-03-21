using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1010
{
    public class Solution1010
    {
    }

    /// <summary>
    /// 暴力
    /// 插入排序 + 二分查找，如果每次都插入最小值，O(n^2)
    /// </summary>
    public class StreamRank : Interface1010
    {
        public StreamRank()
        {
            list = [];
        }

        private List<int> list;

        public void Track(int x)
        {
            list.Add(x);
            for (int i = list.Count - 1; i > 0 && list[i] < list[i - 1]; i--) (list[i - 1], list[i]) = (list[i], list[i - 1]);
        }

        public int GetRankOfNumber(int x)
        {
            int result = -1, lo = 0, hi = list.Count - 1, mid;
            while (lo <= hi)
            {
                mid = lo + ((hi - lo) >> 1);
                if (list[mid] <= x) { result = mid; lo = mid + 1; } else hi = mid - 1;
            }

            return result + 1;
        }
    }
}
