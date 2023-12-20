using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2903
{
    public class Solution2903_2 : Interface2903
    {
        /// <summary>
        /// 双指针
        /// 思路同Solution2903_oth
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="indexDifference"></param>
        /// <param name="valueDifference"></param>
        /// <returns></returns>
        public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
        {
            if (indexDifference >= nums.Length) return new int[] { -1, -1 };

            int maxid = 0, minid = 0, len = nums.Length;
            for (int i = 0, j = indexDifference; j < len; i++, j++)
            {
                if (nums[i] > nums[maxid]) maxid = i; else if (nums[i] < nums[minid]) minid = i;
                if (nums[maxid] - nums[j] >= valueDifference) return new int[] { maxid, j };
                if (nums[j] - nums[minid] >= valueDifference) return new int[] { minid, j };
            }

            return new int[] { -1, -1 };
        }
    }
}
