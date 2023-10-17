using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0933
{
    public class Solution0933
    {
    }

    /// <summary>
    /// 二分
    /// </summary>
    public class RecentCounter : Interface0933
    {
        public RecentCounter()
        {
            list = new List<int>();
        }

        private List<int> list;

        public int Ping(int t)
        {
            list.Add(t);
            int left = -1, low = 0, high = list.Count - 1, mid, target = t - 3000;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (list[mid] >= target)
                {
                    left = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return list.Count - left;
        }
    }
}
