using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2080
{
    public class Solution2080_2
    {
    }

    /// <summary>
    /// 类前缀和
    /// 时间上不会有问题，空间复杂度是O(n^2)
    /// 
    /// 不出意外的MLE了
    /// </summary>
    public class RangeFreqQuery_2 : Interface2080
    {
        public RangeFreqQuery_2(int[] arr)
        {
            int n = arr.Length;
            freq = new Dictionary<int, int>[n + 1];
            freq[0] = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                Dictionary<int, int> _freq = new Dictionary<int, int>(freq[i]);
                if (_freq.ContainsKey(arr[i])) _freq[arr[i]]++; else _freq.Add(arr[i], 1);
                freq[i + 1] = _freq;
            }
        }

        private Dictionary<int, int>[] freq;

        public int Query(int left, int right, int value)
        {
            if (!freq[right + 1].ContainsKey(value)) return 0;
            if (!freq[left].ContainsKey(value)) return freq[right + 1][value];

            return freq[right + 1][value] - freq[left][value];
        }
    }
}
