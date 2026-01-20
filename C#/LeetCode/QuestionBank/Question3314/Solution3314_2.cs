using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3314
{
    public class Solution3314_2 : Interface3314
    {
        /// <summary>
        /// 位运算
        /// 一个整数x，x+1相等于把x的最低位的0改为1，这一位后面全部改为0
        /// 所以，x | x+1 相等于把x的最低位的0改为1
        /// 那么这里相等于已知 y = x | x+1，已知y，求x，就相当于把y的最低位连续的1中的最高位的1改为0即可
        /// 题目要求最小的x，现在问题变成，前面解出的x是不是最小解，或唯一解？
        /// 证明好证，反证法即可，这里就不描述了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MinBitwiseArray(IList<int> nums)
        {
            int len = nums.Count;
            int[] result = new int[len];
            for (int i = 0, j = -1, num; i < len; i++, j = -1)
            {
                result[i] = -1; num = nums[i];
                if (num == 2) continue;              // 题目限定了质数，所以只有这一个偶数（特殊情况）
                while (((num >> (++j)) & 1) != 0) ;
                result[i] = num ^ (1 << (j - 1));
            }

            return result;
        }
    }
}
