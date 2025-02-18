using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2080
{
    public class Solution2080
    {
    }

    /// <summary>
    /// 暴力
    /// 意料之中的TLE
    /// </summary>
    public class RangeFreqQuery : Interface2080
    {
        public RangeFreqQuery(int[] arr)
        {
            this.arr = arr;
        }

        private int[] arr;

        public int Query(int left, int right, int value)
        {
            int cnt = 0;
            for (int i = left; i <= right; i++) if (arr[i] == value) cnt++;

            return cnt;
        }
    }
}
