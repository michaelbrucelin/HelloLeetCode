using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0912
{
    public class Solution0912 : Interface0912
    {
        /// <summary>
        /// 归并
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArray(int[] nums)
        {
            _SortArray(0, nums.Length - 1);
            return nums;

            void _SortArray(int l, int r)
            {
                if (l >= r) return;
                int mid = l + ((r - l) >> 1);
                _SortArray(l, mid);
                _SortArray(mid + 1, r);

                int[] cache = new int[r - l + 1];
                int p = 0, pl = l, pr = mid + 1;
                while (pl <= mid && pr <= r) if (nums[pl] <= nums[pr]) cache[p++] = nums[pl++]; else cache[p++] = nums[pr++];
                while (pl <= mid) cache[p++] = nums[pl++];
                while (pr <= r) cache[p++] = nums[pr++];

                p = 0;
                for (int i = l; i <= r; i++) nums[i] = cache[p++];
            }
        }
    }
}
