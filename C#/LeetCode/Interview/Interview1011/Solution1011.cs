using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1011
{
    public class Solution1011 : Interface1011
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        public void WiggleSort(int[] nums)
        {
            int len = nums.Length;
            Func<int, int, bool>[] funcs = [(x, y) => x >= y, (x, y) => x <= y];
            for (int i = 1, j = 0; i < len; i++, j = 1 - j)
            {
                if (!funcs[j](nums[i - 1], nums[i])) (nums[i - 1], nums[i]) = (nums[i], nums[i - 1]);
            }
        }

        public void WiggleSort2(int[] nums)
        {
            int len = nums.Length;
            Func<int, int, bool>[] funcs = [(x, y) => x <= y, (x, y) => x >= y];
            for (int i = 1; i < len; i++)
            {
                if (!funcs[i & 1](nums[i - 1], nums[i])) (nums[i - 1], nums[i]) = (nums[i], nums[i - 1]);
            }
        }
    }
}
