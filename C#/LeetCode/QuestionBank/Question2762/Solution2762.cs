using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2762
{
    public class Solution2762 : Interface2762
    {
        /// <summary>
        /// 双指针（滑动窗口） + 稀疏表
        /// 使用稀疏表快速查找一个子数组的最大值与最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long ContinuousSubarrays(int[] nums)
        {
            sparsetable st = new sparsetable(nums);

            long result = 0;
            int pl = -1, pr = 0, len = nums.Length;
            while (++pl < len)
            {
                while (pr + 1 < len && st.diff(pl, pr + 1) < 3) pr++;
                result += pr - pl + 1;
            }

            return result;
        }

        public class sparsetable
        {
            public sparsetable(int[] nums)
            {
                minst = [[.. nums]];
                maxst = [[.. nums]];
                int span = 2, half = 1, len = nums.Length;
                while (span <= len)
                {
                    minst.Add(new int[len - span + 1]);
                    maxst.Add(new int[len - span + 1]);
                    for (int i = 0, j = half, k = span - 1; k < len; i++, j++, k++)
                    {
                        minst[^1][i] = Math.Min(minst[^2][i], minst[^2][j]);
                        maxst[^1][i] = Math.Max(maxst[^2][i], maxst[^2][j]);
                    }
                    span <<= 1; half <<= 1;
                }
            }

            private List<int[]> minst;
            private List<int[]> maxst;

            public int diff(int left, int right)
            {
                int span = 1, idx = 0;
                while ((span << 1) <= right - left + 1) { span <<= 1; idx++; }
                return Math.Max(maxst[idx][left], maxst[idx][right - span + 1]) - Math.Min(minst[idx][left], minst[idx][right - span + 1]);
            }
        }
    }
}
