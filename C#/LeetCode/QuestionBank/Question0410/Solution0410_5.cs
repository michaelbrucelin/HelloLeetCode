using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0410
{
    public class Solution0410_5 : Interface0410
    {
        /// <summary>
        /// 二分法
        /// 逻辑同Solution0410_4，不过"验证"方法中也使用了二分法，不一定更优，就是写着玩的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SplitArray(int[] nums, int k)
        {
            if (k == 1) return nums.Sum();
            if (k == nums.Length) return nums.Max();

            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + nums[i];

            int result = -1, left = nums.Max(), right = sums[len], mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (IsValid(sums, k, mid))
                {
                    result = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        private bool IsValid(int[] sums, int k, int target)
        {
            int p = 1, len = sums.Length, _p, left, right, mid;
            while (p < len && k > 0)
            {
                _p = -1; left = p; right = len - 1;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (sums[mid] - sums[p - 1] <= target)
                    {
                        _p = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                if (_p == -1) return false;
                p = _p + 1; k--;
            }

            return p >= len && k >= 0;
        }
    }
}
