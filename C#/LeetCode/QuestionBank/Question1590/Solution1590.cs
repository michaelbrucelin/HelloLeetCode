using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1590
{
    public class Solution1590 : Interface1590
    {
        /// <summary>
        /// 前缀和 + 暴力查找
        /// 如果子数组的和对p取余的值 与 数组和对p取余的值 相等，这个子数组就是一个解，题目找的是最短的子数组解
        /// 1. 前缀和数组，只需要统计mod p值的前缀和即可
        /// 2. 前缀和数组需要是long类型，int类型可能会溢出
        /// 
        /// 逻辑没问题，TLE，参考测试用06
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public int MinSubarray(int[] nums, int p)
        {
            int len = nums.Length;
            long[] pre = new long[len + 1];
            for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + nums[i] % p;
            if (pre[len] % p == 0) return 0;

            long target = pre[len] % p;
            for (int i = 1; i < len; i++) for (int j = i; j <= len; j++)
                {
                    if ((pre[j] - pre[j - i]) % p == target) return i;
                }

            return -1;
        }
    }
}
