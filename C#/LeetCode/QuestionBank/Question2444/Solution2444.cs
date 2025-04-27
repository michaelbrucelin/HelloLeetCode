using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2444
{
    public class Solution2444 : Interface2444
    {
        /// <summary>
        /// DP
        /// 1. 先DP处理出以nums[i]结尾最小值是minK以及最小值大于等于minK的子数组的数量
        /// 2. 再DP处理出以nums[i]结尾最大值是maxK以及最大值小于等于maxK的子数组的数量
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="minK"></param>
        /// <param name="maxK"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            if (minK > maxK) return 0;

            long result = 0;
            int len = nums.Length;
            int[,] dp_min = new int[len + 1, 2], dp_max = new int[len + 1, 2];
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                switch (num - minK)
                {
                    case 0: dp_min[i + 1, 0] = dp_min[i, 0] + 1; dp_min[i + 1, 1] = dp_min[i, 1] + 1; break;
                    case > 0: dp_min[i + 1, 0] = dp_min[i, 0] + 1; dp_min[i + 1, 1] = dp_min[i, 1]; break;
                    default: break;
                }
                switch (num - maxK)
                {
                    case 0: dp_max[i + 1, 0] = dp_max[i, 0] + 1; dp_max[i + 1, 1] = dp_max[i, 1] + 1; break;
                    case < 0: dp_max[i + 1, 0] = dp_max[i, 0] + 1; dp_max[i + 1, 1] = dp_max[i, 1]; break;
                    default: break;
                }
                result += Math.Min(dp_min[i + 1, 1], dp_max[i + 1, 1]);
            }

            return result;
        }
    }
}
