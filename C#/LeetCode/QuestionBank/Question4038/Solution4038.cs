using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4038
{
    public class Solution4038 : Interface4038
    {
        /// <summary>
        /// 状态机
        /// 记录每个值的上一个索引的位置
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountSpecialIntegers(int[] nums)
        {
            int result = 0, len = nums.Length;
            int[] last = new int[101];
            Array.Fill(last, -1);
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                switch ((last[num], i - last[num]))
                {
                    case (-1, _): result++; last[num] = i; break;
                    case (-2, _): break;
                    case (_, 1): last[num] = i; break;
                    case (_, _): result--; last[num] = -2; break;
                }
            }

            return result;
        }
    }
}
