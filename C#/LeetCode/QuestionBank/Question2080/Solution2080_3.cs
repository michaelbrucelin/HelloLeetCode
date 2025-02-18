using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2080
{
    public class Solution2080_3
    {
    }

    /// <summary>
    /// 记录数组中每个元素出现的位置，然后二分查找
    /// </summary>
    public class RangeFreqQuery_3 : Interface2080
    {
        public RangeFreqQuery_3(int[] arr)
        {
            dist = new Dictionary<int, List<int>>();
            int n = arr.Length;
            for (int i = 0, j; i < n; i++)
            {
                j = arr[i];
                if (dist.ContainsKey(j)) dist[j].Add(i); else dist.Add(j, new List<int> { i });
            }
        }

        private Dictionary<int, List<int>> dist;

        public int Query(int left, int right, int value)
        {
            if (!dist.ContainsKey(value) || dist[value][0] > right || dist[value][^1] < left) return 0;

            int _left = dist[value].Count, _right = -1;
            int low = 0, high = dist[value].Count - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (dist[value][mid] >= left) { _left = mid; high = mid - 1; } else { low = mid + 1; }
            }
            if (dist[value][_left] > right) return 0;

            low = _left; high = dist[value].Count - 1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (dist[value][mid] <= right) { _right = mid; low = mid + 1; } else { high = mid - 1; }
            }

            return _right - _left + 1;
        }
    }
}
