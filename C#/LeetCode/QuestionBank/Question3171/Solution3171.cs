using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3171
{
    public class Solution3171 : Interface3171
    {
        /// <summary>
        /// 滑动窗口，双指针
        /// 1. 或 运算具有单调性，或 运算后的值只可能变大（或不变），不可能变小
        ///     所以可以使用双指针维护一个窗口，使其 或 的值，始终比k小，或者“刚刚”越过k
        /// 2. 上一点中有一个问题，就是当[x..y]的 或 值大于k后，[x+1..y]的值怎么计算，
        ///     由于 或 运算没有逆运算，所以不能由前一个窗口获得，那样时间复杂度就是O(n^2)，不可取
        ///     可以使用一个int[32]记录窗口中所有值每一位上 1 的个数，这样就可以实现 或 运算的逆运算了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumDifference(int[] nums, int k)
        {
            if (nums[0] == k) return 0;

            int result = Math.Abs(nums[0] - k);
            int[] freq = new int[32];
            List<int> pos = GetBitPositions(nums[0]);
            foreach (int i in pos) freq[i]++;
            int len = nums.Length, l = 0, r = 0, window = nums[0];
            while (++r < len)
            {
                if (nums[r] == k || (window |= nums[r]) == k) return 0;
                result = Math.Min(result, Math.Abs(window - k));
                pos = GetBitPositions(nums[r]);
                foreach (int i in pos) freq[i]++;
                while (window > k && l < r)
                {
                    pos = GetBitPositions(nums[l]);
                    foreach (int i in pos) if (--freq[i] == 0) window &= ~(1 << i);
                    if (window == k) return 0;
                    result = Math.Min(result, Math.Abs(window - k));
                    l++;
                }
            }
            result = Math.Min(result, Math.Abs(window - k));

            return result;
        }

        private List<int> GetBitPositions(int n)
        {
            List<int> positions = new List<int>();
            int position = 0;

            while (n > 0)
            {
                if ((n & 1) == 1) positions.Add(position);
                n >>= 1;
                position++;
            }

            return positions;
        }
    }
}
