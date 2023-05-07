using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2148
{
    public class Solution2148_3 : Interface2148
    {
        /// <summary>
        /// 分析
        /// 其实就是非最大元素、非最小元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountElements(int[] nums)
        {
            int max = nums[0], maxcnt = 1, min = nums[0], mincnt = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i]; maxcnt = 1;
                }
                else if (nums[i] < min)
                {
                    min = nums[i]; mincnt = 1;
                }
                else
                {
                    if (nums[i] == max) maxcnt++;
                    if (nums[i] == min) mincnt++;
                }
            }

            if (min == max) return 0;
            return nums.Length - maxcnt - mincnt;
        }
    }
}
