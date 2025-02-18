using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2080
{
    public class Solution2080_4
    {
    }

    /// <summary>
    /// 逻辑同Solution2080_3，只是将字典改为了数组，试一下速度
    /// </summary>
    public class RangeFreqQuery_4 : Interface2080
    {
        public RangeFreqQuery_4(int[] arr)
        {
            dist = new List<int>[100001];
            for (int i = 0; i < 100001; i++) dist[i] = new List<int>();
            int n = arr.Length;
            for (int i = 0; i < n; i++) dist[arr[i]].Add(i);
        }

        private List<int>[] dist;

        public int Query(int left, int right, int value)
        {
            if (dist[value].Count == 0 || dist[value][0] > right || dist[value][^1] < left) return 0;

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
