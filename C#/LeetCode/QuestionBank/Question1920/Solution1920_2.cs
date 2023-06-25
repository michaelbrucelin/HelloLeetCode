using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1920
{
    public class Solution1920_2 : Interface1920
    {
        /// <summary>
        /// 原地更改
        /// 由于nums的长度在1000之内，所以每个num只使用的10个位，那么可以用高区的位来记录临时结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] BuildArray(int[] nums)
        {
            int len = nums.Length;
            for (int i = 0; i < len; i++) nums[i] |= nums[nums[i]] << 21;
            for (int i = 0; i < len; i++) nums[i] >>= 21;

            return nums;
        }
    }
}
