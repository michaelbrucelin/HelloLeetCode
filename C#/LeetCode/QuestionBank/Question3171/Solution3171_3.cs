using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3171
{
    public class Solution3171_3 : Interface3171
    {
        /// <summary>
        /// 逻辑与Solution3171完全相同，将计算得到的整数二进制中1的位置全部记录下来，空间换时间
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumDifference(int[] nums, int k)
        {
            if (nums[0] == k) return 0;

            int result = Math.Abs(nums[0] - k);
            int[] freq = new int[32];
            List<List<int>> poss = new List<List<int>>();
            poss.Add(GetBitPositions(nums[0]));
            foreach (int i in poss[0]) freq[i]++;
            int len = nums.Length, l = 0, r = 0, window = nums[0];
            while (++r < len)
            {
                if (nums[r] == k || (window |= nums[r]) == k) return 0;
                result = Math.Min(result, Math.Abs(window - k));
                poss.Add(GetBitPositions(nums[r]));
                foreach (int i in poss[r]) freq[i]++;
                while (window > k && l < r)
                {
                    foreach (int i in poss[l]) if (--freq[i] == 0) window &= ~(1 << i);
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
