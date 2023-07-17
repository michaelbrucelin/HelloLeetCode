using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0747
{
    public class Solution0747 : Interface0747
    {
        /// <summary>
        /// 分析
        /// 滚动记录数组的最大值与次大值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DominantIndex(int[] nums)
        {
            if (nums.Length == 1) return 0;
            int max, second, maxid;
            if (nums[0] > nums[1])
            {
                max = nums[0]; second = nums[1]; maxid = 0;
            }
            else
            {
                max = nums[1]; second = nums[0]; maxid = 1;
            }

            for (int i = 2, num; i < nums.Length; i++)
            {
                num = nums[i];
                if (num > max)
                {
                    second = max; max = num; maxid = i;
                }
                else if (num > second)
                {
                    second = num;
                }
            }

            return max >= (second << 1) ? maxid : -1;
        }
    }
}
