using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2567
{
    public class Solution2567_2 : Interface2567
    {
        /// <summary>
        /// 分类讨论
        /// 逻辑与Solution2567完全相同，由于只需要排序后最小值，次小值，次次小值，最大值，次大值，次次大值 这6个值，所以没必要排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimizeSum(int[] nums)
        {
            if (nums.Length < 4) return 0;

            int[] mins = [int.MaxValue, int.MaxValue, int.MaxValue], maxs = [int.MinValue, int.MinValue, int.MinValue];
            for (int i = 0, num, len = nums.Length; i < len; i++)
            {
                num = nums[i];
                if (num < mins[0]) { mins[2] = mins[1]; mins[1] = mins[0]; mins[0] = num; } else if (num < mins[1]) { mins[2] = mins[1]; mins[1] = num; } else if (num < mins[2]) mins[2] = num;
                if (num > maxs[0]) { maxs[2] = maxs[1]; maxs[1] = maxs[0]; maxs[0] = num; } else if (num > maxs[1]) { maxs[2] = maxs[1]; maxs[1] = num; } else if (num > maxs[2]) maxs[2] = num;
            }

            int result = maxs[1] - mins[1];
            result = Math.Min(result, maxs[0] - mins[2]);
            result = Math.Min(result, maxs[2] - mins[0]);

            return result;
        }
    }
}
