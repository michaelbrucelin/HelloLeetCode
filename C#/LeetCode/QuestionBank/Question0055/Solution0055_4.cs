using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0055
{
    public class Solution0055_4 : Interface0055
    {
        /// <summary>
        /// 贪心
        /// 同官解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1) return true;

            int reach = 0, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (i > reach) return false;
                reach = Math.Max(reach, i + nums[i]);
                if (reach >= len - 1) return true;
            }

            return false;
        }
    }
}
