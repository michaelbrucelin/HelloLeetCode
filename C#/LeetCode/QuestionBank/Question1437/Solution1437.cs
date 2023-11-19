using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1437
{
    public class Solution1437 : Interface1437
    {
        /// <summary>
        /// 遍历
        /// 先找到第1个1，后面每个1前面至少需要有k个0
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool KLengthApart(int[] nums, int k)
        {
            if (k == 0) return true;

            int ptr = 0, len = nums.Length;
            while (ptr < len)
            {
                while (ptr < len && nums[ptr] == 0) ptr++;  // 找到1个1
                if (ptr == len) return true;
                for (int i = 0; i < k && ++ptr < len; i++) if (nums[ptr] == 1) return false;
            }

            return true;
        }
    }
}
