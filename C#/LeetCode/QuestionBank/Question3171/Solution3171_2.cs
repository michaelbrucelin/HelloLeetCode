using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3171
{
    public class Solution3171_2 : Interface3171
    {
        /// <summary>
        /// 逻辑与Solution3171完全相同，只是使用int[]代替List<int>缓存整数1的位置，节省内存
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumDifference(int[] nums, int k)
        {
            if (nums[0] == k) return 0;

            int result = Math.Abs(nums[0] - k);
            int[] freq = new int[32], _freq = new int[32];
            GetBitPositions(nums[0]);
            for (int i = 0; i < 32; i++) freq[i] += _freq[i];
            int len = nums.Length, l = 0, r = 0, window = nums[0];
            while (++r < len)
            {
                if (nums[r] == k || (window |= nums[r]) == k) return 0;
                result = Math.Min(result, Math.Abs(window - k));
                GetBitPositions(nums[r]);
                for (int i = 0; i < 32; i++) freq[i] += _freq[i];
                while (window > k && l < r)
                {
                    GetBitPositions(nums[l]);
                    for (int i = 0; i < 32; i++) if ((freq[i] -= _freq[i]) == 0) window &= ~(1 << i);
                    if (window == k) return 0;
                    result = Math.Min(result, Math.Abs(window - k));
                    l++;
                }
            }
            result = Math.Min(result, Math.Abs(window - k));

            return result;

            void GetBitPositions(int n)
            {
                Array.Fill(_freq, 0);

                int position = 0;

                while (n > 0)
                {
                    _freq[position] = n & 1;
                    n >>= 1;
                    position++;
                }
            }
        }
    }
}
