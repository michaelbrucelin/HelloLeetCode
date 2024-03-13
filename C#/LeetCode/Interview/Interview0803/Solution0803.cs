using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0803
{
    public class Solution0803 : Interface0803
    {
        /// <summary>
        /// 二分
        /// 没办法二分，具体见官解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMagicIndex(int[] nums)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 暴力查找
        /// 审题不严谨，没有读到数组是有序的。。。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMagicIndex2(int[] nums)
        {
            int result = -1;
            for (int i = 0; i < nums.Length; i++) if (nums[i] == i) return i;

            return result;
        }
    }
}
